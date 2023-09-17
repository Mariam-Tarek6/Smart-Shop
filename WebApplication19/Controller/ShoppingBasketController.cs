using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication19.Model; // Make sure your namespaces match

namespace WebApplication19.Controller // Make sure your namespaces match
{
    [ApiController]
    [Route("ShoppingBasket")]
    public class ShoppingBasketController : ControllerBase
    {
        private readonly SmartShopContext _context;

        public ShoppingBasketController(SmartShopContext context)
        {
            _context = context;
        }

        [HttpPost("addProducts")]
        public async Task<IActionResult> AddProductsToBasket(int basketId, AddProductsToBasketDTO productsDTO)
        {
            var userId = HttpContext.Session.GetInt32("ID");
            if(userId == 0)
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var shoppingBasket = await _context.shoppingBaskets
                    .Include(b => b.shoppingBasketItems)
                    .FirstOrDefaultAsync(b => b.id == basketId);

                if (shoppingBasket == null)
                {
                    return NotFound("Basket not found");
                }

                double totalPrice = 0.0;

                foreach (var productItem in productsDTO.Products)
                {
                    var product = await _context.products.FindAsync(productItem.ProductId);

                    if (product == null)
                    {
                        return NotFound($"Product with ID {productItem.ProductId} not found");
                    }

                    var newBasketItem = new ShoppingBasketItem
                    {
                        Quantity = productItem.Quantity,
                        ProductId = productItem.ProductId
                    };

                    shoppingBasket.shoppingBasketItems.Add(newBasketItem);
                    totalPrice += product.Price * productItem.Quantity;
                    var historyEntry = new ShoppingBasketHistory
                    {
                        ProductId = productItem.ProductId,
                        Quantity = productItem.Quantity,
                        OperationTimestamp = DateTime.Now,
                        ClientId = shoppingBasket.clientId.HasValue ? shoppingBasket.clientId.Value : 0,
                    };
                    if (userId.HasValue)
                    {
                        historyEntry.ClientId = userId.Value;
                    }
                    else
                    {
                        return Unauthorized();
                    }
                        
                    _context.ShoppingBasketHistories.Add(historyEntry);
                    _context.SaveChanges();
                }
                await _context.SaveChangesAsync();
                shoppingBasket.totalPrice = totalPrice;
                await _context.SaveChangesAsync();
                string x = "Products added to basket successfully " + totalPrice;
                return Ok(x);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
        [HttpGet("{basketId}/history")]
        public async Task<IActionResult> GetBasketHistory(int basketId)
        {
            try
            {
                // Retrieve the shopping basket
                var shoppingBasket = await _context.shoppingBaskets
                    .Include(b => b.shoppingBasketItems)
                    .FirstOrDefaultAsync(b => b.id == basketId);

                if (shoppingBasket == null)
                {
                    return NotFound("Basket not found");
                }

                // Retrieve the product IDs that were added to the basket
                var productIdsAdded = shoppingBasket.shoppingBasketItems
                    .Select(item => item.ProductId)
                    .ToList();

                // Fetch the history entries related to these product IDs
                var basketHistory = await _context.ShoppingBasketHistories
                    .Where(history => productIdsAdded.Contains(history.ProductId))
                    .ToListAsync();

                return Ok(basketHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
