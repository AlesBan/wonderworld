namespace Wonderworld.Domain.Entities.Communication;

public class Feedback
{
    public Guid FeedbackId { get; set; }
    
    public Guid TeacherFeedbackSenderId { get; set; }
    public Guid TeacherFeedbackRecipientId { get; set; }
    
    public bool WasTheJointLesson  { get; set; }
    public string? ReasonForNotConducting  { get; set; }
    
    public string? FeedbackText { get; set; }
    public int Rating { get; set; }
}