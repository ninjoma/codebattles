using System.Security.Claims;
using codebattle_api.Exceptions;

public static class AuthExtension
{ 
    public static int GetUserId(this ClaimsPrincipal user){
        var userId = user.FindFirst(ClaimTypes.Upn);
        if (userId != null && userId.Value != null && int.TryParse(userId.Value, out int result)){
            return result;
        }
        throw new CodeBattleException(ErrorCode.MissingData);
    }
}