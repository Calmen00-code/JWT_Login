using Mango.Web.Models.DTO;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> CreateCoupon(CouponDTO coupon);
        Task<ResponseDTO?> GetCoupons();
        Task<ResponseDTO?> GetCoupon(CouponDTO coupon);
    }
}
