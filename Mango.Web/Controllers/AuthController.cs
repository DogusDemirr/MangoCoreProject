using Newtonsoft.Json;
using Mango.Web.Models;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			LoginRequestDto loginRequestDto = new();
			return View(loginRequestDto);
		}


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(obj);
            }
        }


        [HttpGet]
		public IActionResult Register() 
		{
			var roleList = new List<SelectListItem>()
			{
				new SelectListItem{Text=RegisterRole.RoleAdmin, Value=RegisterRole.RoleAdmin},
                new SelectListItem{Text=RegisterRole.RoleCustomer, Value=RegisterRole.RoleCustomer},
            };

		   ViewBag.RoleList = roleList;
           return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto obj)
        {
			ResponseDto result = await _authService.RegisterAsync(obj);
			ResponseDto assignRole;

			if(result !=null && result.IsSuccess)
			{
				if (string.IsNullOrEmpty(obj.Role))
				{
					obj.Role = RegisterRole.RoleCustomer;
				}
				assignRole = await _authService.AssignRoleAsync(obj);
				if(assignRole !=null && assignRole.IsSuccess)
				{
					TempData["Success"] = "Registration Succesful";
					return RedirectToAction(nameof(Login));
				}
			}

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=RegisterRole.RoleAdmin, Value=RegisterRole.RoleAdmin},
                new SelectListItem{Text=RegisterRole.RoleCustomer, Value=RegisterRole.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
			return View(obj);

        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
