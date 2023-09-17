using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication19.Model;

namespace WebApplication19.Controller
{
    [ApiController]
    [Route("Category")]
    public class CategoryController:ControllerBase
    {
        public SmartShopContext _context;
        public CategoryController(SmartShopContext context)
        {
            _context = context;
        }
        
        [HttpGet("AllCategory")]
        public ActionResult<IEnumerable<CategoryWithProductsDTO>> GetCategoryWithProducts()
        {
            var categoriesWithProducts = _context.categories
                .AsNoTracking()
                .ToList();

            return Ok(categoriesWithProducts);
        }


    }
}
