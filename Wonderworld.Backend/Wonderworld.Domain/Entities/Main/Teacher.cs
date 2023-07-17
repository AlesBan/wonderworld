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

    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public Guid EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }

    public string Aims { get; set; }
    public string Description { get; set; }

    public string PhotoUrl { get; set; }
    public string BannerPhotoUrl { get; set; }

    public Guid InterfaceLanguage { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsVerified { get; set; }
    public DateTime VerifiedAt { get; set; }

    public DateTime LastOnlineAt { get; set; }

    public DateTime DeletedAt { get; set; }
}