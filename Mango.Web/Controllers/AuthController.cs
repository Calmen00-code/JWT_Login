using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new LoginRequestDTO(); 
            return View(loginRequestDTO);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem { Text=SD.RoleAdmin, Value = SD.RoleAdmin },
                new SelectListItem { Text=SD.RoleCustomer, Value = SD.RoleCustomer }
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            ResponseDTO? response = await _authService.LoginAsync(loginRequestDTO);

            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO? loginResponse =
                    JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(loginRequestDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequest)
        {
            ResponseDTO? response = await _authService.RegisterAsync(registrationRequest);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem { Text=SD.RoleAdmin, Value = SD.RoleAdmin },
                new SelectListItem { Text=SD.RoleCustomer, Value = SD.RoleCustomer }
            };

            ViewBag.RoleList = roleList;
            return View(registrationRequest);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
