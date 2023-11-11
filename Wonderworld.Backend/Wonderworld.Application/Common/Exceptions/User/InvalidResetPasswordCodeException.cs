using Wonderworld.Application.Interfaces.Exceptions;

namespace Wonderworld.Application.Common.Exceptions.User;

public class InvalidResetPasswordCodeException : Exception, IUiException
{
    public InvalidResetPasswordCodeException()
        : base("Invalid reset password code")
    {
    }
}