using AutoMapper;
using LoginJWT.Services.CouponAPI.Models;
using LoginJWT.Services.CouponAPI.Models.DTO;

namespace LoginJWT.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}
