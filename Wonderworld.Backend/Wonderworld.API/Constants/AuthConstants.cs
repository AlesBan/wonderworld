namespace Wonderworld.API.Constants;

public static class AuthConstants
{
    public static readonly DateTime TokenLifeTime = DateTime.UtcNow.AddHours(6);

    public const string InvalidPayloadErrorMessage = "Invalid payload";
    public const string UserAlreadyExistsErrorMessage = "User already exists";
    public const string UserNotFoundErrorMessage = "User not found";
    public const string InvalidCredentialsErrorMessage = "Invalid credentials";
    public const string SomethingWentWrongErrorMessage = "Something went wrong";
    public const string OkObjectResultIsNotUserAsExpectedErrorMessage = "OkObjectResult is not User as expected";
    public const string UserAlreadyCreatedAccountErrorMessage = "User already created account error message";}