using LoginJWT.Services.CouponAPI.Data;
using LoginJWT.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginJWT.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                return coupons;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(u => u.CouponId == id);
                return coupon;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
