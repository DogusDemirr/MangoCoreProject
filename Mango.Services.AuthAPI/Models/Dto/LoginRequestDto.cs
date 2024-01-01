namespace Mango.Services.AuthAPI.Models.Dto
{
	public class LoginRequestDto
	{
		/// <summary>
		/// UserName
		/// </summary>
        public string UserName { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; set; }
    }
}
