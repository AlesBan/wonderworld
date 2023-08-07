using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Communication;

public class Review
{
    public Guid ReviewId { get; set; }
    public Guid InvitationId { get; set; }
    public Invitation Invitation { get; set; }
    public Guid UserSenderId { get; set; }
    public User UserSender { get; set; }
    public Guid UserRecipientId { get; set; }
    public User UserRecipient { get; set; }
    public bool WasTheJointLesson  { get; set; }
    public string? ReasonForNotConducting  { get; set; }
    public string? ReviewText { get; set; }
    public int? Rating { get; set; }
}