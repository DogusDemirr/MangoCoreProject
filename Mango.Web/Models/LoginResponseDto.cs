namespace Mango.Web.Models
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
