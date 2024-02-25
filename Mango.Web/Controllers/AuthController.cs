using Newtonsoft.Json;
using Mango.Web.Models;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Mango.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;
		public AuthController(IAuthService authService,ITokenProvider tokenProvider)
		{
			_authService = authService;
            _tokenProvider = tokenProvider;
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
                await SıgnInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        private async Task SıgnInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                jwt.Claims.FirstOrDefault(u=>u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
               jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
