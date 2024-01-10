using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.ExternalService.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ExternalService.Implementations
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public TokenResponseDto CreateToken(AppUser user, int expiredate = 60)
		{
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name , user.UserName),
				new Claim (ClaimTypes.Email , user.Email),
				new Claim(ClaimTypes.NameIdentifier , user.Id),
				new Claim(ClaimTypes.GivenName , user.Name)
			};
			Console.WriteLine(_configuration["Jwt:SigninKey"]);
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigninKey"]));
			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			// 5 dene ctor u var
			JwtSecurityToken jwtSecurity = new JwtSecurityToken(
			   issuer: _configuration["Jwt:Issuer"],
			   audience: _configuration["Jwt:Audience"],
			   claims: claims,
			   notBefore: DateTime.UtcNow,
			   expires: DateTime.UtcNow.AddMinutes(expiredate),
			   signingCredentials: credentials
			  );

			JwtSecurityTokenHandler tokenHandler = new();
			string token = tokenHandler.WriteToken(jwtSecurity);
			return new()
			{
				Token = token,
				ExpireDate = jwtSecurity.ValidTo,
				UserName = user.UserName,
			};
		}
	}
}
