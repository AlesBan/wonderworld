namespace Wonderworld.API.Models.JwtModels;

public class JwtSettings
{
    public bool ValidateIssuerSigningKey { get; set; }
    public static string IssuerSigningKey { get; set; }
    public static bool ValidateIssuer { get; set; } = true;
    public static string ValidIssuer { get; set; }
    public static bool ValidateAudience { get; set; } = true;
    public static string ValidAudience { get; set; }
    public bool RequireExpirationTime { get; set; }
    public bool ValidateLifetime { get; set; } = true;
}