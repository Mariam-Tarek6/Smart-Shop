using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication19.Model;
using System.Xml.Linq;

namespace WebApplication19.Controller
{
        [ApiController]
        [Route("Product")]
    public class ProductController:ControllerBase
    {
        public SmartShopContext _context;

        public ProductController(SmartShopContext context)
        {
            _context = context;
        }
        [HttpGet("NewProduct")]
        public ActionResult GetNew()
        {
            var product=_context.products.Take(8).ToList();
            return Ok(product);
        }
        
        [HttpGet("GetByCategory")]
        public ActionResult GetByCategory(int id)
        {
            var products=_context.products.AsNoTracking().Where(p => p.CategoryId == id).ToList();
            return Ok(products);
        }
        [HttpGet("GetAllProduct")]
        public ActionResult GetProducts(int page = 1)
        {
            int pageSize = 10;
            var products = _context.products.AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(products);
        }
        [HttpGet("FilterColor")]
        public ActionResult FilterColor(int id, int page = 1)
        {
            int pageSize = 10;

            var products = _context.products.AsNoTracking()
            .Where(p => p.ProductColors.Any(pc => pc.ColorId == id))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Ok(products);
        }
        [HttpGet("FilterSize")]
        public ActionResult FilterSize(int id, int page = 1)
        {
            int pageSize = 10;

            var products = _context.products.AsNoTracking()
            .Where(p => p.ProductSizes.Any(pc => pc.SizeId == id))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return Ok(products);
        }
        [HttpGet("GetProduct")]
        public ActionResult GetProduct2(int id)
        {
            int totalRating = 0;
            int commentCount = _context.comments.Where(x => x.ProductId == id).Count();
            int averageRating;
            if (commentCount == 0)
            {

                averageRating = 0;


            }
            else
            {
                foreach (var comment in _context.comments)
                {
                    totalRating += comment.CommentRate;
                }
                averageRating = totalRating / commentCount;
            }
            var update=_context.products.AsNoTracking().Where(x=>x.Id == id).FirstOrDefault();
            Product product2 = new Product()
            {
                Id = id,
                Brand = update.Brand,
                Category = update.Category,
                CategoryId = update.CategoryId,
                Comments = update.Comments,
                Description = update.Description,
                Name = update.Name,
                Price = update.Price,
                PriceAfterDiscount = update.PriceAfterDiscount,
                ProductColors = update.ProductColors,
                ProductSizes = update.ProductSizes,
                ShoppingBasketItems = update.ShoppingBasketItems,
                Rate =averageRating,
                image=update.image
                 
            };
            _context.products.Update(product2);
             _context.SaveChanges();
            var product = _context.products
                .AsNoTracking()
                .Include(p => p.ProductSizes)  // Include ProductSizes navigation property
                    .ThenInclude(ps => ps.Size)  // Include related Size entity
                .Include(p => p.ProductColors)  // Include ProductColors navigation property
                    .ThenInclude(pc => pc.Color)  // Include related Color entity
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(product, jsonOptions);

            return Content(json, "application/json");
        }
        [HttpGet("Search")]
        public ActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search)) {
                return NoContent();
            }
            var find= from a in _context.products
                      where a.Name.Contains(search)|| a.Brand.Contains(search)
                      select a;
            if (find.Any())
            {
                return Ok(find);
            }
            return NotFound();
        }
        //public int rate(int id) {
        //    int totalRating = 0;
        //    int commentCount = _context.comments.Where(x=>x.ProductId==id).Count();

        //    if(commentCount == 0) {

        //        return 0;

        //    }
        //    foreach (var comment in _context.comments)
        //    {
        //        totalRating += comment.CommentRate;
        //    }
        //    int averageRating = totalRating / commentCount;
        //    return averageRating;
        //}                               
    }
}
