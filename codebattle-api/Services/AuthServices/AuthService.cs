using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using codebattle_api.DTO;
using codebattle_api.utils;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace codebattle_api.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserDTO user)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretManager.GetSecret("EncryptionKey") ?? ""));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,  user.Username),
            };

            var token = new JwtSecurityToken(
                issuer: "codebattle-web", //TODO: Implementar que lo extraiga de la llamada
                audience: _configuration["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public Task<UserDetailDTO> GetTokenUserName(string token)
        {
            throw new NotImplementedException();
        }
    }
}