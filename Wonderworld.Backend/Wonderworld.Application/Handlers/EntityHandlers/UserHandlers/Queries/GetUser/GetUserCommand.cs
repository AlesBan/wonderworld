using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;

public class GetUserCommand : IRequest<User>
{
    public Guid UserId { get; set; }

    public GetUserCommand(Guid userId)
    {
        UserId = userId;
    }
}