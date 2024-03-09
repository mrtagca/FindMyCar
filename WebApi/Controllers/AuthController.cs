using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly IConfiguration _configuration;
		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost]
        public void Login(string username,string password)
        {
			//user pass validation

			var claims = GenerateUserClaims(username);

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expiry = DateTime.Now.AddMinutes(10);

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: expiry, signingCredentials: signIn);

			string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
		}
		 
		private Claim[] GenerateUserClaims(string username)
		{
			return new[] {
					new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
					new Claim("Username", username),
			   };
		}
	}
}
