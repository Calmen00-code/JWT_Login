using LoginJWT.Services.AuthAPI.Models;

namespace LoginJWT.Services.AuthAPI.Service
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
