using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Helpers;

public class PasswordHelper
{
    public static void SetUserPasswordHash(User user, string password)
    {
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
    }

    public static void VerifyPasswordHash(User user, string password)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8
            .GetBytes(password));

        var passwordHashMatches = computedHash.SequenceEqual(user.PasswordHash);

        if (!passwordHashMatches)
        {
            throw new InvalidInputCredentialsException("Wrong password provided");
        }
    }

    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8
            .GetBytes(password));
    }
}