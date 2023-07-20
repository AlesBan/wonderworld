using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Communication;

public class Invitation
{
    public Guid InvitationId { get; set; }

    public Guid UserInvitationSenderId { get; set; }
    public User UserInvitationSender { get; set; }
    
    public Guid UserInvitationRecipientId { get; set; }
    public User UserInvitationRecipient { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string Status { get; set; }

    public string? InvitationText { get; set; }
}