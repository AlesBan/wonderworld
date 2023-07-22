using Microsoft.EntityFrameworkCore;
using Wonderworld.Domain.ConnectionEntities;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.Enums;
using Wonderworld.Persistence;

namespace Application.UnitTests.Common;

public class SharedLessonDbContextFactory
{
    public static Guid CountryAId = new Guid("C669544B-65EB-4E82-B89D-2D765408E283");
    public static Guid CountryBId = new Guid("4742865D-A051-46C9-8062-FC8860BAB382");
    public static Guid CountryForDeleteId = new Guid("5F1B352F-C153-4DB6-AB34-60B7916904B2");

    public static Guid CityAId = new Guid("3F83EA5F-137B-46A3-BE10-611E44312650");
    public static Guid CityForDeleteId = new Guid("92CE4A95-71B2-4910-9F6A-186DF2676D9F");
    public static SharedLessonDbContext Create()
    {
        var options = new DbContextOptionsBuilder<SharedLessonDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new SharedLessonDbContext(options);
        context.Database.EnsureCreated();
        context.Users.AddRange(
            new User()
            {
                UserId = new Guid("9D13C7FF-18E0-4C71-8DB0-B7F05B420CEA"),
                Email = "registered@a.com",
                Password = "12345reg"
            });
        
        AppendCountries(context);
        AppendCities(context);
        
        context.SaveChanges();
        return context;
    }

    private static void AppendCountries(SharedLessonDbContext context)
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

    private static void AppendCities(SharedLessonDbContext context)
    {
        context.Cities.AddRange(
            new City()
            {
                CityId = CityAId,
                CountryId = CountryAId,
                Title = "CityA"
            },
            new City
            {
                CityId = CityForDeleteId,
                CountryId = CountryBId,
                Title = "CityForDelete"
            });
    }

    public static User RegisteredUserA = new User
    {
        UserId = new Guid("9D13C7FF-18E0-4C71-8DB0-B7F05B420CEA"),
        Email = "registered@a.com",
        Password = "12345reg",
        UserRoles = null,
        FirstName = null,
        LastName = null,
        IsATeacher = false,
        IsAnExpert = false,
        Classes = null,
        AppointmentId = default,
        Appointment = null,
        EstablishmentId = default,
        Establishment = null,
        CityLocationId = default,
        CityLocation = null,
        TeacherLanguages = null,
        TeacherDisciplines = null,
        ReceivedInvitations = null,
        SentInvitations = null,
        ReceivedFeedbacks = null,
        SentFeedbacks = null,
        Aims = null,
        Description = null,
        PhotoUrl = null,
        BannerPhotoUrl = null,
        InterfaceLanguageId = default,
        InterfaceLanguage = null,
        RegisteredAt = default,
        CreatedAt = default,
        IsVerified = false,
        VerifiedAt = default,
        LastOnlineAt = default,
        DeletedAt = default
    };

    public static User UserA = new User
    {
        UserId = new Guid("5DF18BD8-27FD-42C2-BC25-C1590E8D7CA0"),
        Email = "a@a.com",
        Password = "12345",
        FirstName = "UserA",
        LastName = "UserA",
        IsATeacher = true,
        IsAnExpert = false,
        UserRoles = new List<UserRole>
        {
            new UserRole()
            {
                RoleId = new Guid("BB4A3323-85E7-4CBB-A596-1FCD313A898C"),
                UserId = new Guid("5DF18BD8-27FD-42C2-BC25-C1590E8D7CA0"),
            },
        },
        Classes = new List<Class>
        {
            ClassA,
        },
        Appointment = new Appointment()
        {
            AppointmentId = new Guid("E04A7E37-49E8-4C21-80E5-C92E70CD19AB"),
            Title = "Teacher"
        },
        Establishment = new Establishment()
        {
            Title = "EstablishmentA",
            CityId = new Guid("5DF18BD8-27FD-42C2-BC25-C1590E8D7CA0"),
            City = CityA
        },
        CityLocation = new City()
        {
            CityId = new Guid("A450594D-1A4B-4DB3-BC52-C8DE26BA26E9"),
            Title = "CityLocationA"
        },
        TeacherLanguages = null,
        TeacherDisciplines = null,
        ReceivedInvitations = null,
        SentInvitations = null,
        ReceivedFeedbacks = null,
        SentFeedbacks = null,
        Aims = "Aims",
        Description = "Description",
        PhotoUrl = null,
        BannerPhotoUrl = null,
        InterfaceLanguage = new InterfaceLanguage()
        {
            LanguageId = new Guid("BA377885-C448-4226-90B5-1040936A4350"),
            Title = "InterfaceLanguage"
        },
        RegisteredAt = default,
        CreatedAt = default,
        IsVerified = false,
        VerifiedAt = default,
        LastOnlineAt = default,
        DeletedAt = default
    };

    public static User UserB = new User()
    {
        UserId = new Guid("270BC2EE-34AC-4D2F-8BD2-19D7743C550F"),
        FirstName = "UserB",
        LastName = "UserB",
        Email = "b@b.com",
        Password = "12345",
        IsATeacher = true,
        IsAnExpert = false,
    };

    public static Role TeacherRole = new Role()
    {
        RoleId = new Guid("BB4A3323-85E7-4CBB-A596-1FCD313A898C"),
        Title = "Teacher",
    };

    public static readonly Class ClassA = new Class()
    {
    };


    private static readonly Country CountryA = new Country()
    {
        CountryId = new Guid("EC64F4E6-199C-4F2E-BFF6-7970859636A1"),
        Title = "Country"
    };

    private static readonly City CityA = new City()
    {
        CityId = new Guid("5DF18BD8-27FD-42C2-BC25-C1590E8D7CA0"),
        Title = "City",
        CountryId = new Guid("EC64F4E6-199C-4F2E-BFF6-7970859636A1"),
        Country = CountryA
    };

    public static Language Language = new Language()
    {
        LanguageId = new Guid("5159EF03-501E-48E8-A6EB-4B5655C867FC"),
        Title = "Language"
    };

    public static void Destroy(SharedLessonDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}