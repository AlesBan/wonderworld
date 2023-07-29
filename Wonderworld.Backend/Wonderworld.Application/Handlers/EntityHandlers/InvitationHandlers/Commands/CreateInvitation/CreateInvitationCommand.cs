using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommand : IRequest<Guid>
{
    public User UserInvitationSender { get; set; }
    public User UserInvitationRecipient { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string? InvitationText { get; set; }
}