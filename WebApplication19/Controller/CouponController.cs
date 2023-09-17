using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication19.Controller
{
    [ApiController]
    [Route("Coupon")]
    public class CouponController : ControllerBase
    {
        private readonly SmartShopContext _context;
        public CouponController(SmartShopContext context)
        {
            _context = context;
        }
        [HttpGet("CheckCoupon")]
        public ActionResult couponCheck(string coupon)
        {
            var check = _context.coupons.Where(x => x.Name == coupon).FirstOrDefault();
            if (check != null)
            {
                return Ok(check);
            }
            return NotFound();
        }
    }
}
