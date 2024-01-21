using Mango.Web.Models;
using Mango.Web.Service.IService;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
	public class AuthService : IAuthService
	{
		private readonly IBaseService _baseService;
		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		/// <summary>
		/// AssignRoleAsync
		/// </summary>
		/// <param name="registerationRequestDto"></param>
		/// <returns></returns>
		public async Task<ResponseDto?> AssignRoleAsync(RegisterationRequestDto registerationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.POST,
				Data = registerationRequestDto,
				Url = $"{AuthAPIBase.TrimEnd('/')}/api/auth/AssignRole"
			});
		}

		/// <summary>
		/// LoginAsync
		/// </summary>
		/// <param name="loginRequestDto"></param>
		/// <returns></returns>
		public async  Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.POST,
				Data = loginRequestDto,
				Url = $"{AuthAPIBase.TrimEnd('/')}/api/auth/login"
			});
		}

		/// <summary>
		/// RegisterAsync
		/// </summary>
		/// <param name="registerationRequestDto"></param>
		/// <returns></returns>
		public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registerationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.POST,
				Data = registerationRequestDto,
				Url = $"{AuthAPIBase.TrimEnd('/')}/api/auth/register"
			});
		}
	}
}
