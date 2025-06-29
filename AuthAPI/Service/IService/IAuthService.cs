using LoginJWT.Services.AuthAPI.DTO;

namespace LoginJWT.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO newUserRequest);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
    }
}
