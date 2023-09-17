using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication19.Model
{
    public class ShoppingBasketItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
      //  [ForeignKey("ShoppingBasketId")]
        public ShoppingBasket ShoppingBasket { get; set; }
        public int ShoppingBasketId { get; set; }
      //  [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
