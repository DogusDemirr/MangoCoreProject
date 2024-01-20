namespace Mango.Web.Models
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

		/// <summary>
		/// Role
		/// </summary>
		public string? Role { get; set; }	
	}
}
