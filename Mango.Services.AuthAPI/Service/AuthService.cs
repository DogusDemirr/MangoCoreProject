using Mango.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;

namespace Mango.Services.AuthAPI.Service
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

		public Task<LoginRequestDto> Login(LoginRequestDto loginRequestDto)
		{
			return null;
		}

		public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
		{
			ApplicationUser user = new()
			{
				UserName = registerationRequestDto.Email,
				Email = registerationRequestDto.Email,
				NormalizedEmail = registerationRequestDto.Email.ToUpper(),
				Name = registerationRequestDto.Name,
				PhoneNumber = registerationRequestDto.PhoneNumber
			};

			try
			{
				var result = await _userManager.CreateAsync(user, registerationRequestDto.Password);
				if (result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registerationRequestDto.Email);

					UserDto userDto = new()
					{
						Email = userToReturn.Email,
						ID = int.Parse(userToReturn.Id), //bakılacak!!
						Name = userToReturn.Name,
						PhoneNumber = userToReturn.PhoneNumber
					};
					return string.Empty;
				}
				else
				{
					return result.Errors.FirstOrDefault().Description;
				}
			}
			catch (Exception ex) {
				return $"{ex.Message}";
			}
		}
	}
}
