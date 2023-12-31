using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wonderworld.Application.Helpers;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.Enums.EntityTypes;
using Wonderworld.Persistence.EntityConfiguration.Communication;
using Wonderworld.Persistence.EntityConfiguration.Job;
using Wonderworld.Persistence.EntityConfiguration.Location;
using Wonderworld.Persistence.EntityConfiguration.Main;
using Wonderworld.Persistence.EntityConnectionsConfiguration;
using Wonderworld.Persistence.EntityTypeConfiguration.Communication;
using Wonderworld.Persistence.EntityTypeConfiguration.Education;
using InstitutionType = Wonderworld.Domain.Entities.Job.InstitutionType;

namespace Wonderworld.Persistence;

public static class ModelBuilderExtensions
{
    public static void AppendConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new GradeConfiguration());
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());

        modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
        modelBuilder.ApplyConfiguration(new InstitutionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new InvitationConfiguration());

        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserGradeConfiguration());
        modelBuilder.ApplyConfiguration(new UserDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ClassDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new ClassLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new InstitutionTypeInstitutionConfiguration());
    }

    public static void SeedingDefaultData(this ModelBuilder modelBuilder, IConfiguration? configuration)
    {
        modelBuilder.SeedingGrades();
        modelBuilder.SeedingDisciplines(configuration);
        modelBuilder.SeedingLanguages();
        modelBuilder.SeedingRoles();
        modelBuilder.SeedingEstablishmentTypes();
    }

    private static void SeedingGrades(this ModelBuilder modelBuilder)
    {
        var grades = Enumerable.Range(1, 12)
            .Select(i => new Grade()
            {
                GradeId = Guid.NewGuid(),
                GradeNumber = i
            })
            .ToList();

        modelBuilder.Entity<Grade>()
            .HasData(grades);
    }

    private static void SeedingDisciplines(this ModelBuilder modelBuilder, IConfiguration configuration)
    {
        var filePath = configuration["DefaultData:DisciplinesFilePath"];
        var disciplines = FileHelper.GetLines(filePath);
        modelBuilder.Entity<Discipline>().HasData(disciplines
            .Select(d =>
                new Discipline
                {
                    DisciplineId = Guid.NewGuid(),
                    Title = d.ToString()
                }).ToList());
    }

    private static void SeedingLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(((LanguageType[])
            Enum.GetValues(typeof(LanguageType))).Select(l =>
            new Language
            {
                LanguageId = Guid.NewGuid(),
                Title = l.ToString()
            }).ToList());
    }

    private static void SeedingRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
            .HasData(((RoleType[])
                    Enum.GetValues(typeof(RoleType)))
                .Select(r =>
                    new Role()
                    {
                        RoleId = Guid.NewGuid(),
                        Title = r.ToString()
                    }).ToList());
    }

    private static void SeedingEstablishmentTypes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstitutionType>()
            .HasData(
                Enum.GetValues(typeof(Wonderworld.Domain.Enums.EntityTypes.InstitutionType))
                    .Cast<Wonderworld.Domain.Enums.EntityTypes.InstitutionType>()
                    .Select(et => new InstitutionType
                    {
                        InstitutionTypeId = Guid.NewGuid(),
                        Title = et.ToString()
                    })
                    .ToArray()
            );
    }
}