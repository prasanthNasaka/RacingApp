using System.Security.Claims;

namespace infinitemoto.BusinessServices
{
    public interface IJwtService
    {
       string GenerateToken (string username);
       ClaimsPrincipal ValidateToken(string token);
    }
}
