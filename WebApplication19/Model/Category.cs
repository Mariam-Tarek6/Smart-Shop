using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication19.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [JsonIgnore] // Add this attribute to ignore the circular reference
        public List<Product> Products { get; set; }
    }
    public class CategoryWithProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
