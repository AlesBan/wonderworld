using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserRoleHandlers.Commands.CreateUserRole;

public class CreateUserRoleCommand : IRequest
{
    public User User { get; set; }
    public Role Role { get; set; }
}