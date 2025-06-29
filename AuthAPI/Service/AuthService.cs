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
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db,
                           UserManager<ApplicationUser> userManager,
                           RoleManager<IdentityRole> roleManager,
                           IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            ApplicationUser? user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (user == null || !isValid)
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            UserDTO userDTO = new UserDTO()
            {
                Email = user.Email,
                ID = user.Id,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name
            };

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                User = userDTO,
                Token = token
            };

            return loginResponseDTO;
        }

        public async Task<string> Register(RegistrationRequestDTO newUserRequest)
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

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
            }

            // something wrong if we get to here, return empty user dto
            return "";
        }
    }
}
