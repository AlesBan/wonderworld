namespace Wonderworld.Domain.Entities.Communication;

public class TeacherInvitation
{
    public Guid TeacherInvitationId { get; set; }
    
    public Guid TeacherInvitationSenderId { get; set; }
    public Guid TeacherInvitationRecipientId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime DateOfInvitation { get; set; }
    public string Status { get; set; }

    public string? InvitationText { get; set; }
    
}