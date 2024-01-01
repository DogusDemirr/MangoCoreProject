namespace Mango.Services.AuthAPI.Models.Dto
{
	public class RegisterationRequestDto
	{
		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// PhoneNumber
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; set; }
	}
}
