namespace Mango.Services.AuthAPI.Models
{
	public class JwtOptions
	{
		/// <summary>
		/// Issuer
		/// </summary>
		public string Issuer { get; set; } = string.Empty;

		/// <summary>
		/// Audience
		/// </summary>
		public string Audience {  get; set; } = string.Empty;

		/// <summary>
		/// Secret
		/// </summary>
		public string Secret { get; set; } = string.Empty;
	}
}
