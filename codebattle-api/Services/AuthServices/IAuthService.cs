using codebattle_api.DTO;

namespace codebattle_api.Services.AuthServices{
    public interface IAuthService {
        Task<string> GenerateToken(string email, string password);
        Task<UserDetailDTO> GetTokenUser(string token);
    }
}