using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Main;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public bool? IsATeacher { get; set; }
    public bool? IsAnExpert { get; set; }
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public Guid? EstablishmentId { get; set; }
    public Establishment? Establishment { get; set; }
    public Guid? CityId { get; set; }
    public City? City { get; set; }
    public Guid? CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();
    public ICollection<UserDiscipline> UserDisciplines { get; set; } = new List<UserDiscipline>();
    public ICollection<UserGrade> UserGrades { get; set; } = new List<UserGrade>();
    public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();
    public ICollection<Invitation> SentInvitations { get; set; } = new List<Invitation>();
    public ICollection<Review> ReceivedReviews { get; set; } = new List<Review>();
    public ICollection<Review> SentReviews { get; set; } = new List<Review>();
    public double Rating { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
    public string? BannerPhotoUrl { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsVerified { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public DateTime LastOnlineAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}