using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User;

public class UserNotVerifiedException : Exception, IUiException
{
    public UserNotVerifiedException(Guid userId) : base($"User {userId} is not verified")
    {
    }
}