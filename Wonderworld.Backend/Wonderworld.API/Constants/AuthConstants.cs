namespace Wonderworld.API.Constants;

public static class AuthConstants
{
    public static readonly DateTime TokenLifeTime = new DateTime().AddHours(4);

    public const string InvalidPayloadErrorMessage = "Invalid payload";
    public const string UserExistsErrorMessage = "User already exists";
    public const string UserNotFoundErrorMessage = "User not found";
    public const string InvalidCredentialsErrorMessage = "Invalid credentials";
    public const string SomethingWentWrongErrorMessage = "Something went wrong";
    public const string OkObjectResultIsNotUserAsExpectedErrorMessage = "OkObjectResult is not User as expected";
}