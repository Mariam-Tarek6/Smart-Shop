using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication19.Model
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        // [ForeignKey("BasketId")]
        public int? ShoppingBasketid { get; set; }
        [ForeignKey("ShoppingBasketid")]
        public ShoppingBasket? shopping { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        // Add the following properties for password reset
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
    }
    public class ClientLoginDTO
    {
        public string Name { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
    }
    //public class ApplicationUser: IdentityUser
    //{
    //    public string Name { get; set; }
    //    public List<RefreshToken>? RefreshTokens { get; set; }
    //}
    public class RegisterModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
