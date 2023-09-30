using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Wonderworld.API.Constants;
using Wonderworld.Application.Common.Exceptions.Authentication;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Helpers.JwtHelpers;

public static class JwtHelper
{
    public static string CreateToken(User user, IConfiguration configuration)
    {
        var jwtClaims = GetClaims(user);

        var singingKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(configuration.GetValue<string>("JwtSettings:IssuerSigningKey")));
        var expiresTime = AuthConstants.TokenLifeTime;
        var credentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("JwtSettings:ValidIssuer"),
            audience: configuration.GetValue<string>("JwtSettings:ValidAudience"),
            claims: jwtClaims,
            expires: expiresTime,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static Guid GetUserIdFromClaims(HttpContext httpContext)
    {
        var decodedToken = GetTokenFromHeader(httpContext);

        var nameIdentifier = decodedToken.Claims
            .FirstOrDefault(claim =>
                claim.Type == ClaimTypes.NameIdentifier)?
            .Value;

        if (nameIdentifier == null)
        {
            throw new InvalidNameIdentifierClaimException();
        }
        return Guid.Parse(nameIdentifier);
    }

    private static JwtSecurityToken GetTokenFromHeader(HttpContext httpContext)
    {
        var jwtToken = httpContext.Request
            .Headers["Authorization"]
            .ToString();
        var jwtHandler = new JwtSecurityTokenHandler();
        var decodedToken = jwtHandler.ReadJwtToken(jwtToken.Split(' ')[1]);

        return decodedToken;
    }

    private static IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUniversalTime().ToString())
        };

        claims.SetRoleClaims(user);

        return claims;
    }

    private static void SetRoleClaims(this ICollection<Claim> claims, User user)
    {
        user.UserRoles.Select(ur =>
                ur.Role.Title)
            .ToList()
            .ForEach(role =>
                claims.Add(new Claim(ClaimTypes.Role, role)));
    }
}