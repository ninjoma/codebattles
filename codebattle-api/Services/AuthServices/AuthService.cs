using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
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
        /// <returns>JWT Token</returns>
        public string GenerateToken(UserDTO user)
        {
            if (user != null && user.Email != null && user.Username != null)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretManager.GetSecret("EncryptionKey") ?? ""));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]{
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name,  user.Username),
                };

                var token = new JwtSecurityToken(
                    issuer: "codebattle-web", //TODO: Implementar que lo extraiga de la llamada
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(7),
                    signingCredentials: credentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
            return "No data supplied";
        }

        /// <summary>
        /// This Method Registers a user into de app
        /// </summary>
        /// <param name="user"></param>
        /// <returns>JWT Token</returns>
        public async Task<string?> RegisterUser(UserDTO user)
        {
            if (user != null && user.Email != null && user.Username != null && user.Password != null)
            {
                user.Password = PasswordHasher.HashPassword(user.Password);
                var result = await _userRepo.Add(user);
                return GenerateToken(result);
            }
            else
            {
                throw new CodeBattleException(ErrorCode.InvalidInput);
            }
        }

        /// <summary>
        /// This Method Registers a user into de app
        /// </summary>
        /// <param name="user"></param>
        /// <returns>JWT Token</returns>
        public async Task<string?> Login(UserDTO user)
        {
            if (user != null && user.Email != null && user.Password != null)
            {
                var result = await _userRepo.GetBySpec<UserDTO>(x => x.Email != null && x.Email.Equals(user.Email.Trim()));
                if (result != null && result.Password != null)
                {
                    if (PasswordHasher.VerifyPassword(user.Password, result.Password))
                    {
                        return GenerateToken(result);
                    }
                    else
                    {
                        throw new CodeBattleException(ErrorCode.WrongPassword);
                    }
                }
                else
                {
                    throw new CodeBattleException(ErrorCode.WrongEmail);
                }
            }
            throw new CodeBattleException(ErrorCode.InvalidInput);
        }

        public async Task<string?> HandleSsoLogin(string email)
        {
            var user = await _userRepo.GetBySpec<UserDTO>(x => x.Email != null && x.Email.Equals(email.Trim()));
            if(user == null) {
                string username = email.Substring(0, email.IndexOf("@"));
                var otherUsers = await _userRepo.ListBySpec<UserDTO>(x => x.Username != null && x.Username.Equals(username.Trim()));
                user = await _userRepo.Add(new UserDTO {
                    Username = username + otherUsers.Count(),
                    Email = email,
                    Password = "password",
                    CreationDate = DateTime.Now.ToUniversalTime()
                });
            }
            return GenerateToken(user);
        }

        public async Task<string?> GeneratePasswordToken(string email)
        {
            
            var user = await _userRepo.GetBySpec<User>(x => x.Email != null && x.Email.Equals(email.Trim()));
            if(user != null && user.Email != null)
            {
                var PasswordResetToken = RandomTokenGenerator.GenerateToken();
                user.PasswordResetToken = PasswordResetToken;
                await _userRepo.Save();
                return PasswordResetToken;
            }
            throw new CodeBattleException(ErrorCode.WrongEmail); 
        }

        public async Task<bool?> CheckPasswordToken(PasswordDTO passwordDTO)
        {
            if(passwordDTO.NewPassword != null && passwordDTO.RepeatNewPassword != null && passwordDTO.PasswordResetToken != null)
            {
                var user = await _userRepo.GetBySpec<User>(x => x.PasswordResetToken != null && x.PasswordResetToken.Equals(passwordDTO.PasswordResetToken.Trim()));
                if(passwordDTO.NewPassword == passwordDTO.RepeatNewPassword) 
                {
                    user.PasswordResetToken = null;
                    user.Password = PasswordHasher.HashPassword(passwordDTO.NewPassword);
                    await _userRepo.Save();
                    return true;
                }
                if(user != null)
                {
                    throw new CodeBattleException(ErrorCode.PasswordsDontMatch);
                }
            }
            throw new CodeBattleException(ErrorCode.InvalidInput);
        }
    }
}