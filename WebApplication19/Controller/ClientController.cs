// ClientController.cs
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication19.Model;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace WebApplication19.Controller
{
    [Route("Authenticate")]
    [ApiController]
     [AllowAnonymous]
    public class ClientController : ControllerBase
    {
        public readonly IJwtTokenManager _jwtTokenManager;
        public readonly SmartShopContext _context;
        private readonly IConfiguration _configuration;

        public ClientController(IJwtTokenManager jwtTokenManager,SmartShopContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _jwtTokenManager = jwtTokenManager;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Authenticate(string Email,[FromBody] string password)
        {
            var clientLogin = _context.clients.FirstOrDefault(x => x.Email == Email);
            HttpContext.Session.SetInt32("Id", clientLogin.Id);
            var (accessToken, refreshToken) = _jwtTokenManager.Authenticate(Email, password);

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized();
            }
           
            return Ok(new { accessToken, refreshToken });
        }
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            // Invalidate the tokens by removing them from the client-side
            // You can also perform any other necessary cleanup

            // Assuming you're using cookies for session management
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return Ok("Logged out successfully.");
        }
        
        [HttpPost("SignUp")]
        public IActionResult SignUp(string username, [FromBody]string password,string email)
        {
            var checkEmail = _context.clients.Where(x => x.Email == email).FirstOrDefault(); 
            if (checkEmail != null)
            {
                return BadRequest("There is a duplicate in the Email");
            }
            var client = new Client() { Email = email, Password = password, Name = username , Address=null, PhoneNumber=null, Comments=null, shopping=null, ShoppingBasketid=null};
            ShoppingBasket shoppingBaske=new ShoppingBasket();
            _context.clients.Add(client);
            _context.SaveChanges();
            shoppingBaske.Notes = null;
            shoppingBaske.client= client;
             shoppingBaske.totalPrice = 0;
            shoppingBaske.TotalPriceAfterDiscount = 0;
            shoppingBaske.clientId = client.Id;
            _context.shoppingBaskets.Add(shoppingBaske);
            _context.SaveChanges();
            var a = _context.clients.Where(q => q.Id == shoppingBaske.clientId).FirstOrDefault();
            a.ShoppingBasketid = shoppingBaske.id;
            _context.clients.Update(a);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken(string refreshToken)
        {
            // Placeholder for your token validation logic
            // In a real-world scenario, you would validate the refresh token against a database or cache
            bool isRefreshTokenValid = ValidateRefreshToken(refreshToken);

            if (!isRefreshTokenValid)
            {
                return BadRequest("Invalid refresh token.");
            }

            // Generate a new access token
            var accessToken = GenerateAccessToken();

            return Ok(new { accessToken });
        }
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            var user = _context.clients.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Generate a password reset token and set its expiration
            var resetToken = GenerateResetToken();
            user.ResetToken = resetToken;
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1); // Set expiration time

            _context.SaveChanges();

            // Send the reset token to the user's email
            // Implement your email sending logic here

            return Ok(user.ResetToken);
        }

        private string GenerateResetToken()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(string token, [FromBody]string newPassword)
        {
            var user = _context.clients.FirstOrDefault(u => u.ResetToken == token);

            if (user == null || !IsTokenValid(user))
            {
                return BadRequest("Invalid or expired token.");
            }

            user.Password = newPassword;
            user.ResetToken = null;
            user.ResetTokenExpiration = null;

            _context.SaveChanges();

            return Ok("Password reset successful.");
        }

        private bool IsTokenValid(Client user)
        {
            return !string.IsNullOrEmpty(user.ResetToken)
                && user.ResetTokenExpiration.HasValue
                && user.ResetTokenExpiration.Value > DateTime.UtcNow;
        }
        private bool ValidateRefreshToken(string refreshToken)
        {
            var clientWithRefreshToken = _context.clients
                //.Include(c => c.RefreshTokens) // Include the RefreshTokens collection
                .FirstOrDefault(c => c.RefreshTokens.Any(rt => rt.Token == refreshToken));

            if (clientWithRefreshToken != null)
            {
                return false; // Invalid or expired token
            }

            // Additional checks, if needed, e.g., matching against user ID or other criteria

            return true; // Token is valid
        }


        private string GenerateAccessToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new List<Claim>(),
                expires: DateTime.UtcNow.AddMinutes(15), // Set your desired access token expiration time
                signingCredentials: creds
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }

    }
}
    

