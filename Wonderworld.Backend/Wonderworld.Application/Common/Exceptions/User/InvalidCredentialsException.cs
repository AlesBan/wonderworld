namespace Wonderworld.Application.Common.Exceptions.User;

public class InvalidInputCredentialsException : Exception
{
    public InvalidInputCredentialsException() : base("Invalid credentials")
    {
    }
}