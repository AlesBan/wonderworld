using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Authentication;

public class InvalidNameIdentifierClaimException : Exception, IServerException
{
    public InvalidNameIdentifierClaimException() : 
        base("Invalid NameIdentifier claim")
    { 
        
    }  
}