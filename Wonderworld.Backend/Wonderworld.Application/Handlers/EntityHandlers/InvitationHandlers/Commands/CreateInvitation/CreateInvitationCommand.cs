using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommand : IRequest<Unit>
{
    public Guid UserSenderId { get; set; }
    public Guid UserReceiverId { get; set; }
    public Guid ClassSenderId { get; set; }
    public Guid ClassReceiverId { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string Status { get; set; }
    public string? InvitationText { get; set; }
}