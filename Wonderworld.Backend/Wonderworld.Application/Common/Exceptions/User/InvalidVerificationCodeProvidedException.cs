namespace Wonderworld.Application.Common.Exceptions.User;

public class InvalidVerificationCodeProvidedException : Exception
{
    public InvalidVerificationCodeProvidedException() :
        base("Invalid verification code provided.")
    {
    }
}