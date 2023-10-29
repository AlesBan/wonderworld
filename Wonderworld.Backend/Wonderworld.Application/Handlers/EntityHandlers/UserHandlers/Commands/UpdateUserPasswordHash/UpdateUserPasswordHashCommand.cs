using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPasswordHash;

public class UpdateUserPasswordHashCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
}