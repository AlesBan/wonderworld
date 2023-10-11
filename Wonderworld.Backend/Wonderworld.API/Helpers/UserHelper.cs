using MediatR;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByEmail;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Helpers;

public static class UserHelper
{
    public static async Task<User> GetUser(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));

        return user;
    }

    public static async Task<User> GetUser(string email, IMediator mediator)
    {
        var user = await mediator.Send(new GetUserByEmailQuery(email));

        return user;
    }
}