using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication19.Model;

namespace WebApplication19.Controller
{
    [ApiController]
    [Route("Comment")]
    public class CommentController:ControllerBase
    {
        private readonly SmartShopContext _context;
        public CommentController(SmartShopContext context)
        {
            _context = context;
        }
        [HttpGet("GetProductComments")]
        public ActionResult Get(int productId) {
            var comments=_context.comments.Where(comments=>comments.ProductId == productId).ToList();
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);    
        }
        [HttpPost("AddComment")]
        public ActionResult addComment(CommentDto comment)
        {
            var clientID = HttpContext.Session.GetInt32("Id");
            if (clientID.HasValue)
            {
                Comment add = new Comment()
                {
                    ClientId = clientID.Value,
                    CommentDescription = comment.CommentDescription,
                    CommentTitle = comment.CommentTitle,
                    CommentRate = comment.CommentRate,
                    Email = _context.clients.Where(x => x.Id == clientID.Value).Select(x => x.Email).FirstOrDefault(),
                    ProductId = comment.ProductId
                };
                _context.comments.Add(add);
                _context.SaveChanges();
                return Ok();
            }
                return Unauthorized();
        }
        
    }
}
