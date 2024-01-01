namespace Mango.Services.AuthAPI.Models.Dto
{
	public class LoginResponseDto
	{
		/// <summary>
		/// User
		/// </summary>
		public UserDto User { get; set; }

		/// <summary>
		/// Token
		/// </summary>
		public string Token { get; set; }
	}
}
