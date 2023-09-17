using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication19.Model
{
    public class ShoppingBasket
    {
        public int id { get; set; }
        public double totalPrice { get; set; }
        public int qty { get; set; }
        public int? clientId { get; set; }
        [ForeignKey("clientId")]
        public Client? client { get; set; }
        public ICollection<ShoppingBasketItem>  shoppingBasketItems { get; set; }
        public double TotalPriceAfterDiscount { get; set; }
        public string Notes { get; set; }
       
    }
    public class AddProductsToBasketDTO
    {
        public List<ProductToAdd> Products { get; set; }

    }
    public class ShoppingBasketHistory
    {
     public int Id { get; set; }
     public int  ProductId { get; set; }
     public int Quantity { get; set; }
     public DateTime OperationTimestamp { get; set; }
     public int ClientId { get; set; }
    }
}
