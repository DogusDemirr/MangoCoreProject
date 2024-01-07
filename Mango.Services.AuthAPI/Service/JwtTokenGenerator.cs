using System.Text;
using System.Security.Claims;
using Mango.Services.AuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.IdentityModel.Tokens;

namespace Mango.Services.AuthAPI.Service
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly JwtOptions _jwtOptions;
		private readonly ILogger _logger;
		private readonly int SEVEN_DAY = 7;
        public JwtTokenGenerator(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string GenerateToken(ApplicationUser applicationUser)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

			var claimList = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email,applicationUser.Email),
				new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id),
				new Claim(JwtRegisteredClaimNames.Name,applicationUser.UserName)
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{

				Audience = _jwtOptions.Audience,
				Issuer = _jwtOptions.Issuer,
				Subject = new ClaimsIdentity(claimList),
				Expires = DateTime.UtcNow.AddDays(SEVEN_DAY),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);

		}
	}
}
