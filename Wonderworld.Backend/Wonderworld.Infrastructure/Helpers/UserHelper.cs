using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Common.Exceptions.User.Forbidden;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByClass;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByEmail;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserById;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByToken;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Helpers;

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

    public static void CheckUserVerification(User user)
    {
        if (!user.IsVerified)
        {
            throw new UserNotVerifiedException(user.UserId);
        }
    }
    public static async Task<IEnumerable<UserProfileDto>> GetUserProfilesBySearchRequest(SearchRequestDto searchRequest,
        IMediator mediator)
    {
        var query = CreateGetUserProfileListBySearchQueryCommand(searchRequest);

        var userProfileList = (await mediator.Send(query)).ToList();

        return userProfileList;
    }
    
    public static async Task<IEnumerable<UserProfileDto>> GetUserProfilesByDefaultSearchRequest(DefaultSearchRequestDto searchRequest,
        IMediator mediator)
    {
        var query = new GetUserProfileListByDefaultSearchRequestCommand()
        {
            SearchRequest = searchRequest
        };

        var userProfileList = (await mediator.Send(query)).ToList();

        return userProfileList;
    }
    
    private static GetUserProfileListBySearchRequestCommand
        CreateGetUserProfileListBySearchQueryCommand(
            SearchRequestDto searchRequest)
    {
        return new GetUserProfileListBySearchRequestCommand()
        {
            SearchRequest = searchRequest
        };
    }

    private static GetUserByIdQuery CreateGetUserCommand(Guid userId)
    {
        return new GetUserByIdQuery(userId);
    }
}