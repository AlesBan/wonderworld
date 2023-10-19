using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.Authentication;

public class InvalidTokenProvidedException : Exception, IUiException
{
    public InvalidTokenProvidedException() : 
        base("Invalid NameIdentifier claim")
    { 
        
    }  
}