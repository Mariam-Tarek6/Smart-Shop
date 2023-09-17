using WebApplication19.Model;

namespace WebApplication19.Model
{
    public class ProductColor
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}