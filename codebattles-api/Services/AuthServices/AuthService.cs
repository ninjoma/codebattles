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
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly IRepository<UserDTO, User> _userRepo;
        public AuthService(IConfiguration configuration, IRepository<UserDTO, User> userRepo, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _userRepo = userRepo;
            _environment = environment;
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
                SymmetricSecurityKey? key = null;
                if (_environment.IsDevelopment())
                {
                    key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretManager.GetSecret("EncryptionKey") ?? ""));
                }
                else
                {
                    key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("EncryptionKey") ?? "LaSuperMegaPasswordDePruebaPorCulpaDeMicrosoft"));
                }
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]{
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name,  user.Username),
                    new Claim(ClaimTypes.Upn, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, GetUserRole(user)),
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
                // Disable Elevated Privileges for New Users.
                user.IsAdmin = false;
                user.IsPremium = false;
                user.Level = null;
                user.Experience = null;
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
                        throw new CodeBattleException(ErrorCode.WrongLoginData);
                    }
                } else {
                    throw new CodeBattleException(ErrorCode.NotFound);
                }
            }
            throw new CodeBattleException(ErrorCode.InvalidInput);
        }

        public async Task<string?> HandleSsoLogin(string email)
        {
            var user = await _userRepo.GetBySpec<UserDTO>(x => x.Email != null && x.Email.Equals(email.Trim()));
            if (user == null)
            {
                string username = email.Substring(0, email.IndexOf("@"));
                var otherUsers = await _userRepo.ListBySpec<UserDTO>(x => x.Username != null && x.Username.Equals(username.Trim()));
                user = await _userRepo.Add(new UserDTO
                {
                    Username = username + otherUsers.Count(),
                    Email = email,
                    Password = "",
                    IsActive = true
                });
            }
            return GenerateToken(user);
        }

        public async Task<string?> GeneratePasswordToken(string email)
        {

            var user = await _userRepo.GetBySpec<User>(x => x.Email != null && x.Email.Equals(email.Trim()));
            if (user != null && user.Email != null)
            {
                var PasswordResetToken = RandomTokenGenerator.GenerateToken();
                user.PasswordResetToken = PasswordResetToken;
                await _userRepo.Save();
                return PasswordResetToken;
            }
            throw new CodeBattleException(ErrorCode.WrongLoginData);
        }

        public async Task<bool?> CheckPasswordToken(PasswordDTO passwordDTO)
        {
            if (passwordDTO.NewPassword != null && passwordDTO.RepeatNewPassword != null && passwordDTO.PasswordResetToken != null)
            {
                var user = await _userRepo.GetBySpec<User>(x => x.PasswordResetToken != null && x.PasswordResetToken.Equals(passwordDTO.PasswordResetToken.Trim()));
                if (passwordDTO.NewPassword == passwordDTO.RepeatNewPassword)
                {
                    user.PasswordResetToken = null;
                    user.Password = PasswordHasher.HashPassword(passwordDTO.NewPassword);
                    await _userRepo.Save();
                    return true;
                }
                if (user != null)
                {
                    throw new CodeBattleException(ErrorCode.PasswordsDontMatch);
                }
            }
            throw new CodeBattleException(ErrorCode.InvalidInput);
        }

        private string GetUserRole(UserDTO user)
        {
            if (user.IsAdmin != null && (bool)user.IsAdmin)
            {
                return "Admin";
            }
            else if (user.IsPremium != null && (bool)user.IsPremium)
            {
                return "Premium";
            }
            return "User";
        }
    }
}