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
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public AuthService(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_jwtTokenGenerator = jwtTokenGenerator;
		    _userManager = userManager;
		    _roleManager = roleManager;
		}

		public async Task<bool> AssingRole(string email, string roleName)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
			if(user != null)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}
				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

			if(user == null || isValid == false)
			{
				return new LoginResponseDto() { User = null, Token = string.Empty };
			}

			var token = _jwtTokenGenerator.GenerateToken(user);

			UserDto userDto = new()
			{
				Email = user.Email,
				ID = int.Parse(user.Id),
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto()
			{
				User = userDto,
				Token = token
			};
			return loginResponseDto;
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
