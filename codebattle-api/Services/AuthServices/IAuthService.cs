using codebattle_api.DTO;

namespace codebattle_api.Services.AuthServices{
    public interface IAuthService {
        string GenerateToken(UserDTO user);
        Task<UserDetailDTO?> GetTokenUser(string token);
    }
}