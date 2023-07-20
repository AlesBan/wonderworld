using Microsoft.EntityFrameworkCore;
using Wonderworld.Domain.ConnectionEntities;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Persistence;

namespace Application.UnitTests.Common;

public class SharedLessonDbContextFactory
{
    public static SharedLessonDbContext Create()
    {
        var options = new DbContextOptionsBuilder<SharedLessonDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new SharedLessonDbContext(options);
        context.Database.EnsureCreated();
        context.SaveChanges();
        return context;
    }

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
        CityLocationId = default,
        CityLocation = new City()
        {
            CityId = new Guid("A450594D-1A4B-4DB3-BC52-C8DE26BA26E9"),
            Title = "CityLocationA"
        },
        TeacherLanguages = null,
        TeacherDisciplines = null,
        RecievedInvitations = null,
        SentInvitations = null,
        RecievedFeedbacks = null,
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

    public static Establishment EstablishmentA = new Establishment
    {
        EstablishmentId = new Guid("E4CD8C2E-0518-413D-92E3-EAFECA01AC8E"),
        Type = "School",
        Title = "EstablishmentA",
        CityId = CityA.CityId,
        City = CityA,
        Teachers = null
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