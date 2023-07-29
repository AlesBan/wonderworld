using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;
using Wonderworld.Domain.Enums;
using Wonderworld.Persistence;

namespace Application.UnitTests.Common;

public class SharedLessonDbContextFactory
{
    public static readonly Guid UserAId = Guid.NewGuid();
    public static readonly Guid UserBId = Guid.NewGuid();
    public static readonly Guid UserRegisteredId = Guid.NewGuid();
    public static readonly Guid UserForDeleteId = Guid.NewGuid();

    public static readonly Guid CountryAId = Guid.NewGuid();
    public static readonly Guid CountryBId = Guid.NewGuid();
    public static readonly Guid CountryForDeleteId = Guid.NewGuid();

    public static readonly Guid CityAId = Guid.NewGuid();
    public static readonly Guid CityBId = Guid.NewGuid();
    public static readonly Guid CityForDeleteId = Guid.NewGuid();

    public static readonly Guid EstablishmentAId = Guid.NewGuid();
    public static readonly Guid EstablishmentBId = Guid.NewGuid();
    public static readonly Guid EstablishmentForDeleteId = Guid.NewGuid();

    public static readonly Guid ClassAId = Guid.NewGuid();
    public static readonly Guid ClassBId = Guid.NewGuid();
    public static readonly Guid ClassForUpdateId = Guid.NewGuid();
    public static readonly Guid ClassForDeleteId = Guid.NewGuid();

    public static readonly Guid InvitationAId = Guid.NewGuid();
    public static readonly Guid InvitationForDeleteId = Guid.NewGuid();

    public static readonly Guid FeedbackForDeleteId = Guid.NewGuid();

    public static SharedLessonDbContext Create()
    {
        var options = new DbContextOptionsBuilder<SharedLessonDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new SharedLessonDbContext(options);
        context.Database.EnsureCreated();

        AppendCountries(context);
        AppendCities(context);
        AppendEstablishments(context);

        AppendUsers(context);

        AppendClasses(context);
        context.SaveChangesAsync();

        AppendUserDisciplines(context);
        AppendUserLanguages(context);
        AppendUserGrades(context);
        AppendUserRoles(context);
        AppendClassLanguages(context);
        AppendClassDisciplines(context);

        AppendInvitations(context);
        AppendFeedbacks(context);
        
        context.SaveChangesAsync();
        return context;
    }

    private static void AppendUsers(ISharedLessonDbContext context)
    {
        context.Users.AddRange(
            new User()
            {
                UserId = UserRegisteredId,
                Email = "email",
                Password = "password",
            },
            new User
            {
                UserId = UserAId,
                Email = "email",
                Password = "password",
                FirstName = "FirstName",
                LastName = "LastName",
                IsATeacher = true,
                IsAnExpert = false,
                Establishment = context.Establishments.FirstOrDefault(e =>
                    e.EstablishmentId == EstablishmentAId)!,
                CityLocation = context.Cities.FirstOrDefault(c =>
                    c.CityId == CityAId)!,
                ReceivedInvitations = null,
                SentInvitations = null,
                ReceivedFeedbacks = null,
                SentFeedbacks = null,
                Description = "Description",
                PhotoUrl = "PhotoUrl",
                BannerPhotoUrl = "BannerPhotoUrl",
                RegisteredAt = DateTime.Today,
                CreatedAt = DateTime.Today,

                UserRoles = null,
                IsVerified = true,
                VerifiedAt = default,
                LastOnlineAt = DateTime.Today,
                DeletedAt = default,
            },
            new User
            {
                UserId = UserBId,
                Email = "emailB",
                Password = "passwordB",
                FirstName = "FirstNameB",
                LastName = "LastNameB",
                IsATeacher = true,
                IsAnExpert = true,
                Establishment = context.Establishments.FirstOrDefault(e =>
                    e.EstablishmentId == EstablishmentAId)!,
                CityLocation = context.Cities.FirstOrDefault(c =>
                    c.CityId == CityAId)!,
                ReceivedInvitations = null,
                SentInvitations = null,
                ReceivedFeedbacks = null,
                SentFeedbacks = null,
                Description = "Description",
                PhotoUrl = "PhotoUrl",
                BannerPhotoUrl = "BannerPhotoUrl",
                RegisteredAt = DateTime.Today,
                CreatedAt = DateTime.Today,
                UserRoles = null,
                IsVerified = true,
                VerifiedAt = default,
                LastOnlineAt = DateTime.Today,
                DeletedAt = default,
            },
            new User()
            {
                UserId = UserForDeleteId,
                FirstName = "FirstNameForDelete",
                LastName = "LastNameForDelete",
                Email = "emailForDelete",
                Password = "passwordForDelete",
                IsVerified = true
            });
    }

    private static void AppendClasses(SharedLessonDbContext context)
    {
        context.Classes.AddRange(
            new Class()
            {
                UserId = UserAId,
                ClassId = ClassAId,
                Title = "title",
                Grade = context.Grades.FirstOrDefault(g => g.GradeNumber == 10)!,
                Age = 10,
                PhotoUrl = "PhotoUrl",
                CreatedAt = DateTime.Today
            },
            new Class()
            {
                UserId = UserAId,
                ClassId = ClassForUpdateId,
                Title = "title",
                Grade = context.Grades.FirstOrDefault(g => g.GradeNumber == 5)!,
                Age = 10,
                PhotoUrl = "PhotoUrl",
                CreatedAt = DateTime.Today
            },
            new Class()
            {
                UserId = UserAId,
                ClassId = ClassForDeleteId,
                Title = "titleA",
                Grade = context.Grades.FirstOrDefault(g => g.GradeNumber == 5)!,
                Age = 10,
                PhotoUrl = "PhotoUrl",
                CreatedAt = DateTime.Today
            },
            new Class()
            {
                UserId = UserBId,
                ClassId = ClassBId,
                Title = "titleB",
                Grade = context.Grades.FirstOrDefault(g => g.GradeNumber == 6)!,
                Age = 11,
                PhotoUrl = "PhotoUrl",
                CreatedAt = DateTime.Today
            }
        );
    }

    private static void AppendInvitations(ISharedLessonDbContext context)
    {
        context.Invitations.AddRange(
            new Invitation()
            {
                InvitationId = InvitationAId,
                UserSender = context.Users.FirstOrDefault(u => u.UserId == UserAId)!,
                UserRecipient = context.Users.FirstOrDefault(u => u.UserId == UserBId)!,
                ClassSender = context.Classes.FirstOrDefault(c => c.ClassId == ClassAId)!,
                ClassRecipient = context.Classes.FirstOrDefault(c => c.ClassId == ClassBId)!,
                DateOfInvitation = DateTime.Today,
                Status = InvitationStatus.Pending.ToString()
            },
            new Invitation()
            {
                InvitationId = InvitationForDeleteId,
                UserSender = context.Users.FirstOrDefault(u => u.UserId == UserAId)!,
                UserRecipient = context.Users.FirstOrDefault(u => u.UserId == UserBId)!,
                ClassSender = context.Classes.FirstOrDefault(c => c.ClassId == ClassAId)!,
                ClassRecipient = context.Classes.FirstOrDefault(c => c.ClassId == ClassBId)!,
                DateOfInvitation = DateTime.Today,
                Status = InvitationStatus.Pending.ToString()
            }
        );
    }

    private static void AppendFeedbacks(ISharedLessonDbContext context)
    {
        context.Feedbacks.AddRangeAsync(
            new Feedback()
            {
                FeedbackId = FeedbackForDeleteId,
                Invitation = context.Invitations.FirstOrDefault(i
                    => i.InvitationId == InvitationAId)!,
                WasTheJointLesson = true,
                ReasonForNotConducting = null,
                FeedbackText = "ABOBA",
                Rating = 5
            }
        );
    }

    private static void AppendUserRoles(ISharedLessonDbContext context)
    {
        context.UserRoles.AddRangeAsync(
            new UserRole()
            {
                Role = context.Roles.FirstOrDefault(r => r.Title == "User")!,
                User = context.Users.FirstOrDefault(u => u.UserId == UserAId)!
            },
            new UserRole()
            {
                Role = context.Roles.FirstOrDefault(r => r.Title == "User")!,
                User = context.Users.FirstOrDefault(u => u.UserId == UserBId)!
            }
        );
    }

    private static void AppendClassLanguages(ISharedLessonDbContext context)
    {
        context.ClassLanguages.AddRangeAsync(
            new ClassLanguage()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassAId)!,
                Language = context.Languages.FirstOrDefault(l => l.Title == "English")!
            },
            new ClassLanguage()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassForUpdateId)!,
                Language = context.Languages.FirstOrDefault(l => l.Title == "English")!
            },
            new ClassLanguage()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassForDeleteId)!,
                Language = context.Languages.FirstOrDefault(l => l.Title == "English")!
            }
        );
    }

    private static void AppendClassDisciplines(ISharedLessonDbContext context)
    {
        context.ClassDisciplines.AddRangeAsync(
            new ClassDiscipline()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassAId)!,
                Discipline = context.Disciplines.FirstOrDefault(d => d.Title == "Chemistry")!
            },
            new ClassDiscipline()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassForUpdateId)!,
                Discipline = context.Disciplines.FirstOrDefault(d => d.Title == "Chemistry")!
            },
            new ClassDiscipline()
            {
                Class = context.Classes.FirstOrDefault(c => c.ClassId == ClassForDeleteId)!,
                Discipline = context.Disciplines.FirstOrDefault(d => d.Title == "Chemistry")!
            }
        );
    }

    private static void AppendUserGrades(ISharedLessonDbContext context)
    {
        context.UserGrades.AddRange(
            new UserGrade()
            {
                User = context.Users.SingleAsync(u => u.UserId == UserAId).Result!,
                Grade = context.Grades.SingleAsync(g => g.GradeNumber == 10).Result!
            },
            new UserGrade()
            {
                User = context.Users.SingleAsync(u => u.UserId == UserAId).Result!,
                Grade = context.Grades.SingleAsync(g => g.GradeNumber == 6).Result!
            });
    }

    private static void AppendUserDisciplines(ISharedLessonDbContext context)
    {
        context.UserDisciplines.AddRange(
            new UserDiscipline()
            {
                User = context.Users.FirstOrDefault(u => u.UserId == UserAId)!,
                Discipline = context.Disciplines.FirstOrDefault(d => d.Title == "Chemistry")!,
            },
            new UserDiscipline
            {
                User = context.Users.SingleAsync(u => u.UserId == UserAId).Result!,
                Discipline = context.Disciplines.SingleAsync(d => d.Title == "Biology").Result!
            });
    }

    private static void AppendUserLanguages(ISharedLessonDbContext context)
    {
        context.UserLanguages.AddRange(
            new UserLanguage()
            {
                User = context.Users.FirstOrDefault(u => u.UserId == UserAId)!,
                Language = context.Languages.FirstOrDefault(l => l.Title == "English")!
            },
            new UserLanguage()
            {
                User = context.Users.SingleAsync(u => u.UserId == UserAId).Result!,
                Language = context.Languages.SingleAsync(l => l.Title == "Russian").Result!
            },
            new UserLanguage()
            {
                User = context.Users.SingleAsync(u => u.UserId == UserAId).Result!,
                Language = context.Languages.SingleAsync(l => l.Title == "Italian").Result!
            }
        );
    }

    private static void AppendCountries(ISharedLessonDbContext context)
    {
        context.Countries.AddRange(
            new Country()
            {
                CountryId = CountryAId,
                Title = "CountryA"
            },
            new Country
            {
                CountryId = CountryForDeleteId,
                Title = "CountryForDelete"
            });
    }

    private static void AppendCities(ISharedLessonDbContext context)
    {
        context.Cities.AddRange(
            new City()
            {
                CityId = CityAId,
                CountryId = CountryAId,
                Title = "CityA"
            },
            new City()
            {
                CityId = CityBId,
                CountryId = CountryBId,
                Title = "CityB"
            },
            new City
            {
                CityId = CityForDeleteId,
                CountryId = CountryBId,
                Title = "CityForDelete"
            });
    }

    private static void AppendEstablishments(ISharedLessonDbContext context)
    {
        context.Establishments.AddRange(
            new Establishment()
            {
                EstablishmentId = EstablishmentAId,
                Type = EstablishmentTypes.School.ToString(),
                Title = "EstablishmentA",
                CityId = CityAId
            },
            new Establishment()
            {
                EstablishmentId = EstablishmentBId,
                Type = EstablishmentTypes.School.ToString(),
                Title = "EstablishmentB",
                CityId = CityBId
            },
            new Establishment()
            {
                EstablishmentId = EstablishmentForDeleteId,
                Type = EstablishmentTypes.School.ToString(),
                Title = "EstablishmentForDelete",
                CityId = CityAId
            });
    }


    public static void Destroy(SharedLessonDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}