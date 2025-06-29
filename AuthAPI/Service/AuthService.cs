using LoginJWT.Services.AuthAPI.Data;
using LoginJWT.Services.AuthAPI.DTO;
using LoginJWT.Services.AuthAPI.Models;
using LoginJWT.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace LoginJWT.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register(RegistrationRequestDTO newUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
