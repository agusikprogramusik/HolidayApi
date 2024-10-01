using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HolidayApi.Common.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace HolidayApi.TokenService
{
    public class JwtTokenService : IJwtTokenService
    {
        public async Task<AuthToken> Handle(User user)
        {
            var secretKey = "igufadigafdioadfigaiaougfodgog36543651686180953068jgfdfgkkafdkjdfab";
            var expiresTime = DateTime.UtcNow.Add(TimeSpan.FromHours(2));
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                Expires = expiresTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),


            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return new()
            {
                Token = jwtToken,
                Expires = expiresTime
            };
        }
    }
}