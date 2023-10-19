using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User.Forbidden;

public class UserNotVerifiedException : Exception, IUiForbiddenException
{
    public UserNotVerifiedException(Guid userId) : base($"User {userId} is not verified")
    {
    }
}