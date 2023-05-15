using codebattle_api.DTO;

namespace codebattle_api.Services.AuthServices{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
            
        }

        public Task<string> GenerateToken(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailDTO> GetTokenUser(string token)
        {
            throw new NotImplementedException();
        }
    }
}