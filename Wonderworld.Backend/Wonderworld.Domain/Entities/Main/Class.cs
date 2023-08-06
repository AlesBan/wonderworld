using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Main;

public class Class
{
    public Guid ClassId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; }
    public int Age { get; set; }
    public string? PhotoUrl { get; set; } = string.Empty;
    public ICollection<ClassLanguage> ClassLanguages { get; set; } = new List<ClassLanguage>();
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ICollection<ClassDiscipline> ClassDisciplines { get; set; } = new List<ClassDiscipline>();
    public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();
    public ICollection<Invitation> SentInvitations { get; set; } = new List<Invitation>();

    public ICollection<Feedback> ReceivedFeedbacks { get; set; } = new List<Feedback>();
    public ICollection<Feedback> SentFeedbacks { get; set; } = new List<Feedback>();
}