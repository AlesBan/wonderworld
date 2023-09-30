namespace Wonderworld.Application.Common.Exceptions.User;

public class UserAlreadyHasAccountException : Exception
{
    public UserAlreadyHasAccountException(Guid userId) : base($"User {userId} already has account")
    {
    }
}