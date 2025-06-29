using LoginJWT.Services.AuthAPI.DTO;
using LoginJWT.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDTO();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registerRequest)
        {
            var errorMessage = await _authService.Register(registerRequest);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.Message = errorMessage;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
