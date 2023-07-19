using Wonderworld.Domain.ConnectionEntities;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Domain.Entities.Main;

public class Teacher
{
    public Guid TeacherId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    
    public ICollection<Class> Classes { get; set; }

    public Guid? AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public Guid? EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }

    public ICollection<TeacherLanguage> TeacherLanguages { get; set; }
    public ICollection<TeacherDiscipline> TeacherDisciplines { get; set; }
    public ICollection<Invitation> RecievedInvitations { get; set; }
    public ICollection<Invitation> SentInvitations { get; set; }
    public ICollection<Feedback> RecievedFeedbacks { get; set; }
    public ICollection<Feedback> SentFeedbacks { get; set; }
    public string Aims { get; set; }
    public string Description { get; set; }

    public string PhotoUrl { get; set; }
    public string BannerPhotoUrl { get; set; }

    public Guid InterfaceLanguageId { get; set; }
    public InterfaceLanguage InterfaceLanguage { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsVerified { get; set; }
    public DateTime VerifiedAt { get; set; }

    public DateTime LastOnlineAt { get; set; }

    public DateTime DeletedAt { get; set; }
}