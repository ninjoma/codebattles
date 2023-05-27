using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;
using codebattle_api.utils;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace codebattle_api.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<UserDTO, User> _userRepo;
        public AuthService(IConfiguration configuration, IRepository<UserDTO, User> userRepo)
        {
            _configuration = configuration;
            _userRepo = userRepo;
        }

        /// <summary>
        /// This Method Generates a User Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(UserDTO user)
        {
            if (user != null && user.Email != null && user.Username != null){
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
            return "No data supplied";
        }

        /// <summary>
        /// This Method Recovers User Data from a token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UserDetailDTO?> GetTokenUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(token))
            {
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email));
                var usernameClaim = jwtToken.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name));

                if (emailClaim != null)
                {
                    return await _userRepo.GetBySpec<UserDetailDTO>(x => x.Email != null && x.Email.Equals(emailClaim.Value));
                }
            }
            return null;
        }
    }
}