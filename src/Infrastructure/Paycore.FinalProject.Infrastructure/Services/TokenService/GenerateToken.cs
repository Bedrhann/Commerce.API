using FinalProject.Application.Interfaces.Services.TokenServices;
using FinalProject.Application.Models.JwtToken;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Paycore.FinalProject.Infrastructure.Services.TokenService
{
    public class GenerateToken : IGenerateToken
    {
        readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int day, List<Claim> claims)
        {
            Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials securityKeyEncryption = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.TokenLifeTime = DateTime.UtcNow.AddDays(day);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.TokenLifeTime,
                notBefore: DateTime.UtcNow,
                signingCredentials: securityKeyEncryption,
                claims: claims
                );
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
