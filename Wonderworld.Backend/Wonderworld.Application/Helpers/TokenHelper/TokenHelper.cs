using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Wonderworld.Application.Common;
using Wonderworld.Domain.Entities.Main;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Wonderworld.Application.Helpers.TokenHelper;

public class TokenHelper : ITokenHelper
{
    private readonly IConfiguration _configuration;

    public TokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(User user)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration["JwtSettings:IssuerSigningKey"]));

        var jwtClaims = GetClaims(user);
        var expiresTime = AuthConstants.TokenLifeTime;
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(jwtClaims),
            Expires = expiresTime,
            Issuer = _configuration["JwtSettings:ValidIssuer"],
            Audience = _configuration["JwtSettings:ValidAudience"],
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var signedToken = tokenHandler.WriteToken(token);

        return signedToken;
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
            new("isCreatedAccount", user.IsCreatedAccount.ToString()),
            new("isATeacher", user.IsATeacher.ToString() ?? ""),
            new("isAExpert", user.IsAnExpert.ToString() ?? "")
        };

        // claims.SetRoleClaims(user);

        return claims;
    }
}