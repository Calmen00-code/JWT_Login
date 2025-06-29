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

        public async Task<UserDTO> Register(RegistrationRequestDTO newUserRequest)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = newUserRequest.Email,
                Email = newUserRequest.Email,
                NormalizedEmail = newUserRequest.Email.ToUpper(),
                Name = newUserRequest.Name,
                PhoneNumber = newUserRequest.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser, newUserRequest.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == newUserRequest.Email);

                    UserDTO retUserDTO = new UserDTO()
                    {
                        ID = userToReturn.Id,
                        Email = userToReturn.Email,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return retUserDTO;
                }
            }
            catch (Exception ex)
            {

            }

            // something wrong if we get to here, return empty user dto
            return new UserDTO();
        }
    }
}
