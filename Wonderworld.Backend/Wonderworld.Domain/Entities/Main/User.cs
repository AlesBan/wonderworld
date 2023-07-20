using Wonderworld.Domain.ConnectionEntities;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Domain.Entities.Main;

public class User 
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }

    public ICollection<Class> Classes { get; set; }

    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public Guid EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }

    public Guid CityLocationId { get; set; }
    public City CityLocation { get; set; }

    public ICollection<UserLanguage> TeacherLanguages { get; set; }
    public ICollection<UserDiscipline> TeacherDisciplines { get; set; }

    public ICollection<Invitation> RecievedInvitations { get; set; }
    public ICollection<Invitation> SentInvitations { get; set; }

    public ICollection<Feedback> RecievedFeedbacks { get; set; }
    public ICollection<Feedback> SentFeedbacks { get; set; }

    public string? Aims { get; set; }
    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }
    public string? BannerPhotoUrl { get; set; }

    public Guid InterfaceLanguageId { get; set; }
    public InterfaceLanguage InterfaceLanguage { get; set; }

    public DateTime RegisteredAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public bool IsVerified { get; set; }
    public DateTime VerifiedAt { get; set; }

    public DateTime LastOnlineAt { get; set; }

    public DateTime DeletedAt { get; set; }
}