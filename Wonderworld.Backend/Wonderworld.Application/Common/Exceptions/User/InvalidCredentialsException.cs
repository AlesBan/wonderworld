using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User;

public class InvalidInputCredentialsException : Exception, IUiException
{
    public InvalidInputCredentialsException() : base("Invalid credentials")
    {
    }

    public InvalidInputCredentialsException(string message) : base(message)
    {
        
    }
}