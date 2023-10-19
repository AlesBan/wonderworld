using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Wonderworld.API.Constants;
using Wonderworld.Application.Common.Exceptions.Authentication;
using Wonderworld.Domain.Entities.Main;
using static System.Boolean;

namespace Wonderworld.API.Helpers.JwtHelpers;

public static class JwtHelper
{
    public static string CreateToken(User user, IConfiguration configuration)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(configuration
                .GetValue<string>("JwtSettings:IssuerSigningKey")));

        var jwtClaims = GetClaims(user);
        var expiresTime = AuthConstants.TokenLifeTime;
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(jwtClaims),
            Expires = expiresTime,
            Issuer = configuration.GetValue<string>("JwtSettings:ValidIssuer"),
            Audience = configuration.GetValue<string>("JwtSettings:ValidAudience"),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var signedToken = tokenHandler.WriteToken(token);

        return signedToken;
    }

    public static Guid GetUserIdFromClaims(HttpContext httpContext)
    {
        var decodedToken = GetTokenFromHeader(httpContext);

        var nameIdentifier = decodedToken.Claims
            .FirstOrDefault(claim =>
                claim.Type == "nameid")?
            .Value;

        if (nameIdentifier == null)
        {
            throw new InvalidTokenProvidedException();
        }

        return Guid.Parse(nameIdentifier);
    }

    public static bool GetIsVerifiedFromClaims(HttpContext httpContext)
    {
        var decodedToken = GetTokenFromHeader(httpContext);

        try
        {
            TryParse(decodedToken.Claims
                .FirstOrDefault(claim =>
                    claim.Type == "isVerified")?
                .Value, out var isVerified);

            return isVerified;
        }
        catch
        {
            throw new InvalidTokenProvidedException();
        }
    }

    public static bool GetIsCreatedAccountFromClaims(HttpContext httpContext)
    {
        var decodedToken = GetTokenFromHeader(httpContext);

        try
        {
            TryParse(decodedToken.Claims
                .FirstOrDefault(claim =>
                    claim.Type == "isCreatedAccount")?
                .Value, out var isCreatedAccount);

            return isCreatedAccount;
        }
        catch
        {
            throw new InvalidTokenProvidedException();
        }
    }

    private static JwtSecurityToken GetTokenFromHeader(HttpContext httpContext)
    {
        try
        {
            var jwtToken = httpContext.Request
                .Headers["Authorization"]
                .ToString();
            var jwtHandler = new JwtSecurityTokenHandler();
            var decodedToken = jwtHandler.ReadJwtToken(jwtToken.Split(' ')[1]);

            return decodedToken;
        }
        catch
        {
            throw new InvalidTokenProvidedException();
        }
    }

    private static IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUniversalTime().ToString()),
            new("isVerified", user.IsVerified.ToString()),
            new("isCreatedAccount", user.IsCreatedAccount.ToString())
        };

        // claims.SetRoleClaims(user);

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