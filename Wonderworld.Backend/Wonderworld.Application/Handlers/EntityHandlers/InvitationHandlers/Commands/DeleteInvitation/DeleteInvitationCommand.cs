using MediatR;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.DeleteInvitation;

public class DeleteInvitationCommand : IRequest
{
    public Invitation Invitation { get; set; }
}