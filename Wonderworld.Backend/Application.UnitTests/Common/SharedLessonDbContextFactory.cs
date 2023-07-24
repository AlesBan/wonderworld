using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.Enums;
using Wonderworld.Persistence;

namespace Application.UnitTests.Common;

public class SharedLessonDbContextFactory
{
    public static Guid CountryAId = new Guid("C669544B-65EB-4E82-B89D-2D765408E283");
    public static Guid CountryBId = new Guid("0A103BFC-E34E-49F1-AF43-F4E5203F5E38");
    public static Guid CountryForDeleteId = new Guid("5F1B352F-C153-4DB6-AB34-60B7916904B2");

    public static Guid CityAId = new Guid("3F83EA5F-137B-46A3-BE10-611E44312650");
    public static Guid CityForDeleteId = new Guid("92CE4A95-71B2-4910-9F6A-186DF2676D9F");

    public static Guid EstablishmentAId = new Guid("3403F77F-90DB-48BD-B895-E9D459EEB5AC");
    public static Guid EstablishmentForDeleteId = new Guid("DCC568BB-E09B-42A2-90DC-A0E3C4433AB6");

    public static Guid LanguageAId = new Guid("2A918DF8-75C2-452E-BFF3-7B59E22E94C8");
    public static Guid LanguageForDeleteId = new Guid("573A3A68-1809-4DEB-BD78-DEBB6D81A383");

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
        AppendEstablishments(context);
        AppendLanguages(context);

        context.SaveChanges();
        return context;
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
                EstablishmentId = EstablishmentForDeleteId,
                Type = EstablishmentTypes.School.ToString(),
                Title = "EstablishmentForDelete",
                CityId = CityAId
            });
    }

    private static void AppendLanguages(ISharedLessonDbContext context)
    {
        context.Languages.AddRange(
            new Language()
            {
                LanguageId = LanguageAId,
                Title = "LanguageA"
            },
            new Language()
            {
                LanguageId = LanguageForDeleteId,
                Title = "LanguageForDelete"
            });
    }

    public static void Destroy(SharedLessonDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}