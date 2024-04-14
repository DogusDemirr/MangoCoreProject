using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
	public class RegisterationRequestDto
	{
		[Required]
		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }

        [Required]
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        [Required]
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        [Required]
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        [Required]
        /// <summary>
        /// Role
        /// </summary>
        public string? Role { get; set; }	
	}
}
