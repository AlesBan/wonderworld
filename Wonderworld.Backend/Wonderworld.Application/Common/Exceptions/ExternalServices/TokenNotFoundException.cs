using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.ExternalServices;

public class TokenNotFoundException : Exception, IServerException
{
    public TokenNotFoundException(string tokenPath) : 
        base("Token not found at path: " + tokenPath)
    {
        
    }
}