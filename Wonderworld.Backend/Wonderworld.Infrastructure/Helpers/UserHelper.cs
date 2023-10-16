using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Helpers;

public static class UserHelper
{
    public static async Task<User> GetUserById(Guid userId, IMediator mediator)
    {
        var query = CreateGetUserCommand(userId);

        var user = await mediator.Send(query);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return user;
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
        var query = CreateGetUserProfileListByDefaultSearchRequestCommand(searchRequest);

        var userProfileList = (await mediator.Send(query)).ToList();

        return userProfileList;
    }
    
    private static GetUserProfileListByDefaultSearchRequestCommand
        CreateGetUserProfileListByDefaultSearchRequestCommand(
            DefaultSearchRequestDto searchRequest)
    {
        return new GetUserProfileListByDefaultSearchRequestCommand()
        {
            SearchRequest = searchRequest
        };
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