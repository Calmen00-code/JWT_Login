using LoginJWT.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginJWT.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
