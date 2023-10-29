namespace Wonderworld.Application.Common;

public class AuthConstants
{
    public static readonly DateTime TokenLifeTime = DateTime.UtcNow.AddDays(1);
}