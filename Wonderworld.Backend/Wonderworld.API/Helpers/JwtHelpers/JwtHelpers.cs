using System.Security.Claims;
using Wonderworld.API.Models;

namespace Wonderworld.API.Helpers.JwtHelpers;

public static class JwtHelpers
{
    public static IEnumerable<Claim> GetClaims(this UserToken user, Guid UserId)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
            new Claim(ClaimTypes.Role, user.UserMessage)
        };
            
        return claims;
    }
}