using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateCoupon(CouponDTO coupon)
        {
            RequestDTO request = new RequestDTO()
            {
                ApiType = ApiType.POST,
                Url = SD.CouponBaseAddress + "/api/coupon",
                Data = coupon
            };
            return await _baseService.SendAsync(request);
        }

        public Task<ResponseDTO?> GetCoupon(CouponDTO coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO?> GetCoupons()
        {
            RequestDTO request = new RequestDTO()
            {
                ApiType = ApiType.GET,
                Url = SD.CouponBaseAddress + "/api/coupon"
            };
            return await _baseService.SendAsync(request);
        }
    }
}
