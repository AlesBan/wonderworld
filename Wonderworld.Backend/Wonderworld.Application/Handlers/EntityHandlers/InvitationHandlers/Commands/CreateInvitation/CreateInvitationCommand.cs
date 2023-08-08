using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommand : IRequest<Guid>
{
    public User UserSender { get; set; }
    public User UserRecipient { get; set; }
    public Class ClassSender { get; set; }
    public Class ClassRecipient { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string Status { get; set; }
    public string? InvitationText { get; set; }
}