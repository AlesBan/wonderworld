using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Communication;

public class Invitation
{
    public Guid TeacherInvitationId { get; set; }

    public Guid TeacherInvitationSenderId { get; set; }
    public Teacher TeacherInvitationSender { get; set; }
    
    public Guid TeacherInvitationRecipientId { get; set; }
    public Teacher TeacherInvitationRecipient { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string Status { get; set; }

    public string? InvitationText { get; set; }
}