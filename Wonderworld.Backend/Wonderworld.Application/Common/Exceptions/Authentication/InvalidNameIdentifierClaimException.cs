namespace Wonderworld.Application.Common.Exceptions.Authentication;

public class InvalidNameIdentifierClaimException : Exception
{
    public InvalidNameIdentifierClaimException() : 
        base("Invalid NameIdentifier claim")
    { 
        
    }  
}