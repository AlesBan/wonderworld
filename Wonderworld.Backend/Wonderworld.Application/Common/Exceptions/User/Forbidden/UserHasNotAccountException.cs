using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User.Forbidden;

public class UserHasNotAccountException : Exception, IUiForbiddenException
{
    public UserHasNotAccountException(Guid userId) : base($"User {userId} has not account")
    {
    }
}