using System.Security.Claims;
using codebattle_api.Exceptions;

namespace codebattle_api.utils.Extensions
{
    public static class AuthExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.Upn);
            if (userId != null && int.TryParse(userId, out int parsedId))
            {
                return parsedId;
            }
            throw new CodeBattleException(ErrorCode.MissingTokenData);
        }

        public static string GetUsername(this ClaimsPrincipal user){
            var name = user.FindFirstValue(ClaimTypes.Name);
            if (name != null){
                return name;
            }
            throw new CodeBattleException(ErrorCode.MissingTokenData);
        }

        public static string GetUserRole(this ClaimsPrincipal user){
            var role = user.FindFirstValue(ClaimTypes.Role);
            if (role != null){
                return role;
            }
            throw new CodeBattleException(ErrorCode.MissingTokenData);
        }

        public static string GetUserEmail(this ClaimsPrincipal user){
            var role = user.FindFirstValue(ClaimTypes.Email);
            if (role != null){
                return role;
            }
            throw new CodeBattleException(ErrorCode.MissingTokenData);
        }
    }
}