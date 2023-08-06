using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Wonderworld.API.Constants;
using Wonderworld.API.Interfaces.Auth;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Services.Auth;

public class AuthService : IAuthService
{
    public void SetToken(User user, HttpContext httpContext, IConfiguration configuration)
    {
        var token = CreateToken(user, configuration);

        httpContext.Session.Set("Authorization", Encoding.UTF8.GetBytes(token));
    }

    public static string CreateToken(User user, IConfiguration configuration)
    {
        var jwtClaims = GetClaims(user);

        var singingKey = new SymmetricSecurityKey(Encoding.ASCII
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

    private static IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new("UserId", user.UserId.ToString()),
            new(ClaimTypes.Name, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUniversalTime().ToString())
        };

        user.UserRoles.Select(ur =>
                ur.Role.Title)
            .ToList()
            .ForEach(role =>
                claims.Add(new Claim(ClaimTypes.Role, role)));

        return claims;
    }
}