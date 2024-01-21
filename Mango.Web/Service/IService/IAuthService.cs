using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
	public interface IAuthService
	{
		/// <summary>
		/// LoginAsync
		/// </summary>
		/// <param name="loginRequestDto"></param>
		/// <returns></returns>
		Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);

		/// <summary>
		/// RegisterAsync
		/// </summary>
		/// <param name="loginRequestDto"></param>
		/// <returns></returns>
		Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registerationRequestDto);

		/// <summary>
		/// AssignRoleAsync
		/// </summary>
		/// <param name="loginRequestDto"></param>
		/// <returns></returns>
		Task<ResponseDto?> AssignRoleAsync(RegisterationRequestDto registerationRequestDto);
	}
}
