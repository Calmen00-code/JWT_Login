using LoginJWT.Services.AuthAPI.DTO;
using LoginJWT.Services.AuthAPI.Service.IService;
using Mango.Web.Models.DTO;
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

        [HttpPost("Register")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            LoginResponseDTO loginResponse = await _authService.Login(loginRequest);

            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Incorrect username or password!";
                return BadRequest(_response);
            }
            else
            {
                _response.Result = loginResponse;
                return Ok(_response);
            }
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO registerRequest)
        {
            bool success = await _authService.AssignRole(registerRequest.Email, registerRequest.Role.ToUpper());

            if (!success)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }

            return Ok(_response);
        }
    }
}
