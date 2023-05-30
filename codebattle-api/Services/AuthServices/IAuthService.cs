using codebattle_api.DTO;

namespace codebattle_api.Services.AuthServices{
    public interface IAuthService {
        string GenerateToken(UserDTO user);
        Task<string?> RegisterUser(UserDTO user);
        Task<string?> Login(UserDTO user);

        Task<string?> GeneratePasswordToken(string email);

        Task<bool?> CheckPasswordToken(PasswordDTO passwordDTO);

        Task<string?> HandleSsoLogin(string email);
    }
}