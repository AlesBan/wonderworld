using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public User User { get; set; }
}