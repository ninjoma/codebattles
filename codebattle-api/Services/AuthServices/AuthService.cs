using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using codebattle_api.DTO;
using Microsoft.IdentityModel.Tokens;

namespace codebattle_api.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {

        }

        public string GenerateToken(UserDTO user)
        {
            var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT_ENCRYPTIONKEY"] ?? "Prueba");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Claims
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name,  user.Username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedToken = tokenHandler.WriteToken(token);

            // Retorna el token JWT generado
            return encodedToken;
        }

        public Task<UserDetailDTO> GetTokenUser(string token)
        {
            throw new NotImplementedException();
        }
    }
}