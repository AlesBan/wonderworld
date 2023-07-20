using MediatR;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid UserId { get; set; }
}