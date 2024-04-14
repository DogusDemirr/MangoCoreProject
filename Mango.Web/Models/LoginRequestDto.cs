using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
	public class LoginRequestDto
	{
		[Required]
		/// <summary>
		/// UserName
		/// </summary>
        public string UserName { get; set; }

		[Required]
		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; set; }
    }
}
