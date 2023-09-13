using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Interfaces.Helpers;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Helpers;

public class UserHelper : IUserHelper
{
    private readonly IMediator _mediator;


    public UserHelper(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<User> GetUserById(Guid userId)
    {
        var query = CreateGetUserCommand(userId);

        var user = await _mediator.Send(query);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return user;
    }

    private static GetUserCommand CreateGetUserCommand(Guid userId)
    {
        return new GetUserCommand()
        {
            UserId = userId
        };
    }
}