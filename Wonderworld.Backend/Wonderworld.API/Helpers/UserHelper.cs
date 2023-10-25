using MediatR;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByClass;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByEmail;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserById;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByToken;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Helpers;

public static class UserHelper
{
    public static async Task<User> GetUserById(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));

        return user;
    }

    public static async Task<User> GetUserByEmail(string email, IMediator mediator)
    {
        try
        {
            var user = await mediator.Send(new GetUserByEmailQuery(email));
            return user;
        }
        catch (UserNotFoundException)
        {
            throw new InvalidInputCredentialsException("User with this email does not exist");
        }
    }

    public static async Task<User> GetUserByToken(string token, IMediator mediator)
    {
        try
        {
            var user = await mediator.Send(new GetUserByTokenCommand(token));
            return user;
        }
        catch (UserNotFoundException)
        {
            throw new InvalidTokenProvidedException(token);
        }
    }
    
    public static async Task<Guid> GetUserIdByClassId(Guid classId, IMediator mediator)
    {
        var command = new GetUserIdByClassIdQuery(classId);
        
        var userId = await mediator.Send(command);
        
        return userId;
    }

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

    public static void CheckUserCreateAccountAbility(User user)
    {
        if (user.IsCreatedAccount)
        {
            throw new UserAlreadyHasAccountException(user.UserId);
        }
    }

    public static void CheckUserVerification(User user)
    {
        if (!user.IsVerified)
        {
            throw new UserNotVerifiedException(user.UserId);
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