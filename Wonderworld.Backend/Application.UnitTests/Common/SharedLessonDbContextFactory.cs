using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
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
        context.SaveChanges();

        AppendUsers(context);
        context.SaveChanges();

        AppendUserDisciplines(context);
        AppendUserLanguages(context);
        AppendUserGrades(context);
        context.SaveChanges();
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
                Classes = null,
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