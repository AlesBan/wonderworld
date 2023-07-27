using MediatR;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid UserId { get; set; }
}