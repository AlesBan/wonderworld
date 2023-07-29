using Microsoft.EntityFrameworkCore;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.Enums;
using Wonderworld.Persistence.EntityTypeConfiguration;
using Wonderworld.Persistence.EntityTypeConfiguration.Communication;
using Wonderworld.Persistence.EntityTypeConfiguration.Education;
using Wonderworld.Persistence.EntityTypeConfiguration.Location;
using Wonderworld.Persistence.EntityTypeConfiguration.Main;
using Wonderworld.Persistence.EntityTypeConnectionsConfiguration;

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

        modelBuilder.ApplyConfiguration(new EstablishmentConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new InvitationConfiguration());

        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserGradeConfiguration());
        modelBuilder.ApplyConfiguration(new UserDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ClassDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new ClassLanguageConfiguration());
    }

    public static void SeedingDefaultData(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedingGrades();
        modelBuilder.SeedingDisciplines();
        modelBuilder.SeedingLanguages();
        modelBuilder.SeedingRoles();
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

    private static void SeedingDisciplines(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discipline>().HasData(((DisciplineTypes[])
            Enum.GetValues(typeof(DisciplineTypes))).Select(d =>
            new Discipline
            {
                DisciplineId = Guid.NewGuid(),
                Title = d.ToString()
            }).ToList());
    }

    private static void SeedingLanguages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(((LanguageTypes[])
            Enum.GetValues(typeof(LanguageTypes))).Select(l =>
            new Language
            {
                LanguageId = Guid.NewGuid(),
                Title = l.ToString()
            }).ToList());
    }

    private static void SeedingRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(((RoleTypes[])
            Enum.GetValues(typeof(RoleTypes))).Select(r =>
            new Role()
            {
                RoleId = Guid.NewGuid(),
                Title = r.ToString()
            }).ToList());
    }
}