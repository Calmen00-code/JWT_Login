using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
