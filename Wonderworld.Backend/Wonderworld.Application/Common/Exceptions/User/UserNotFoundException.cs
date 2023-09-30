namespace Wonderworld.Application.Common.Exceptions.User;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string email) :
        base("User with email " + email + " was not found.")
    {
    }

    public UserNotFoundException(Guid id) :
        base("User with id " + id + " was not found.")
    {
    }
}