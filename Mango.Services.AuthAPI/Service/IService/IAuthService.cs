using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		/// <summary>
		/// Register
		/// </summary>
		/// <param name="registerationRequestDto"></param>
		/// <returns></returns>
		Task<string> Register(RegisterationRequestDto registerationRequestDto);

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="loginRequestDto"></param>
		/// <returns></returns>
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
	}
}
