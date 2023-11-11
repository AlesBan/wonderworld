using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User;

public class ResetTokenHasExpiredException : Exception, IUiException
{
    public ResetTokenHasExpiredException( Guid userId, string token) :
        base($"Reset token ({token}) of user with {userId} id has expired.")
    {
    }
}