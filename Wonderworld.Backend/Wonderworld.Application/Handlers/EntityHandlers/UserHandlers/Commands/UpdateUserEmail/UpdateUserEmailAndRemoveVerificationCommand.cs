using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;

public class UpdateUserEmailAndRemoveVerificationCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
}