namespace Wonderworld.Application.Common.Exceptions.Authentication;

public class TokenNotFoundException : Exception
{
    public TokenNotFoundException(string tokenPath) : 
        base("Token not found at path: " + tokenPath)
    {
        
    }
}