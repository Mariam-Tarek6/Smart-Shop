using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication19.Controller;
using WebApplication19.Model;

namespace WebApplication19
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly SmartShopContext _context;

        public JwtTokenManager(IConfiguration configuration, SmartShopContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public (string accessToken, string refreshToken) Authenticate(string email, string password)
        {
            var user = _context.clients.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                return (null, null);
            }

            var key = _configuration.GetValue<string>("JwtConfig:Key") ?? "default-secret-key";
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Set your desired access token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.CreateToken(accessTokenDescriptor);

            var refreshToken = GenerateRefreshToken();
            SaveRefreshToken(user.Id, refreshToken); // Save the refresh token in the database

            return (tokenHandler.WriteToken(accessToken), refreshToken);
        }

        private void SaveRefreshToken(int userId, string refreshToken)
        {
            var user = _context.clients.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var refreshTokenEntity = new RefreshToken
                {
                    CreatedOn = DateTime.UtcNow,
                    RevokedOn = null,
                    userId = userId,
                    Token = refreshToken,
                    ExpiresOn = DateTime.UtcNow.AddMonths(1) // Set the expiration time for the refresh token
                };

                user.RefreshTokens.Add(refreshTokenEntity);

                // Update other properties of the user entity as needed
                user.Email = user.Email;
                user.Address = user.Address;
                user.Comments = user.Comments;
                user.Name = user.Name;
                user.Password = user.Password;
                user.PhoneNumber = user.PhoneNumber;
                user.ResetToken = user.ResetToken;
                user.ResetTokenExpiration = user.ResetTokenExpiration;
                user.shopping = user.shopping;
                user.ShoppingBasketid = user.ShoppingBasketid;

                _context.SaveChanges();
            }
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public string GeneratePasswordResetToken(string email)
        {
            var user = _context.clients.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null; // User not found
            }

            // Generate a password reset token and set its expiration
            var resetToken = GenerateResetToken();
            user.ResetToken = resetToken;
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1); // Set expiration time

            _context.SaveChanges();

            return resetToken;
        }

        public bool ValidatePasswordResetToken(string token)
        {
            var user = _context.clients.FirstOrDefault(u => u.ResetToken == token);

            if (user == null || !IsTokenValid(user))
            {
                return false; // Invalid or expired token
            }

            return true;
        }

        public bool ResetPassword(string token, string newPassword)
        {
            var user = _context.clients.FirstOrDefault(u => u.ResetToken == token);

            if (user == null || !IsTokenValid(user))
            {
                return false; // Invalid or expired token
            }

            user.Password = newPassword;
            user.ResetToken = null;
            user.ResetTokenExpiration = null;

            _context.SaveChanges();

            return true;
        }
        private string GenerateResetToken()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        private bool IsTokenValid(Client user)
        {
            return !string.IsNullOrEmpty(user.ResetToken)
                && user.ResetTokenExpiration.HasValue
                && user.ResetTokenExpiration.Value > DateTime.UtcNow;
        }

        
        //public string Authenticate(string email, string password)
        //{
        //    var user = _context.clients.Where(u => u.Email == email && u.Password == password);

        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    var key = _configuration.GetValue<string>("JwrConfig:Key");
        //    var keyBytes = Encoding.ASCII.GetBytes(key);
        //    var tokenHandeler = new JwtSecurityTokenHandler();
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, email)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token=tokenHandeler.CreateToken(tokenDescriptor);
        //    return tokenHandeler.WriteToken(token); 
        //}
    }
}
