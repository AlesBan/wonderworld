using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User;

public class InvalidTokenProvidedException : Exception, IUiException
{
    public InvalidTokenProvidedException(string token) : base($"Invalid token ({token}) provided.")
    {
    }
}