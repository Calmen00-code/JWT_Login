﻿using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO> coupons = new();
            var response = await _couponService.GetCoupons();

            if (response != null && response.IsSuccess)
            {
                coupons = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            else
            {

            }
            return View(coupons);
        }

        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDTO coupon)
        {
            var response = await _couponService.CreateCoupon(coupon);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("CouponIndex", "Coupon");
            }
            else
            {
                return View(coupon);
            }
        }
    }
}
