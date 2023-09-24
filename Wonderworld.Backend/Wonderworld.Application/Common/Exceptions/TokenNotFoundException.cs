namespace Wonderworld.Application.Common.Exceptions;

public class TokenNotFoundException : Exception
{
    public TokenNotFoundException(string tokenPath) : 
        base("Token not found at path: " + tokenPath)
    {
        
    }
}