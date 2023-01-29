using FilmowaBaza.Domain.Settings;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Security.Claims;

namespace FilmowaBaza.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly JWTSettings _settings;
        public JWTService(IConfiguration configuration)
        {
            this._settings = configuration.GetSection("JWTSettings").Get<JWTSettings>();
        }
        public string CreateToken(long userId)
        {
            var now = DateTime.Now;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(), ClaimValueTypes.Integer64),
            };

            var expires = now.AddMinutes(_settings.TimeToExpiry);
            var signingCredentails = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey)), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentails
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }
    }
}
