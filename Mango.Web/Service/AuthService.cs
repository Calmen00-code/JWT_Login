using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            RequestDTO requestDTO = new RequestDTO()
            {
                ApiType = ApiType.GET,
                Data = registrationRequestDTO,
                Url = SD.AuthBaseAddress + "/api/auth/AssignRole"
            };

            return await _baseService.SendAsync(requestDTO);
        }

        public async Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            RequestDTO requestDTO = new RequestDTO()
            {
                ApiType = ApiType.GET,
                Data = loginRequestDTO,
                Url = SD.AuthBaseAddress + "/api/auth/Login"
            };

            return await _baseService.SendAsync(requestDTO);
        }

        public async Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            RequestDTO requestDTO = new RequestDTO()
            {
                ApiType = ApiType.POST,
                Data = registrationRequestDTO,
                Url = SD.AuthBaseAddress + "/api/auth/Register"
            };

            return await _baseService.SendAsync(requestDTO);
        }
    }
}
