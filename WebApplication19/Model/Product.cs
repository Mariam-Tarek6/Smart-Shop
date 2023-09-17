using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication19.Model
{
    public class ProductToAdd
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? PriceAfterDiscount { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public string Brand { get; set; }
        public string image { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //  [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ShoppingBasketItem> ShoppingBasketItems { get; set; }
    }
}
