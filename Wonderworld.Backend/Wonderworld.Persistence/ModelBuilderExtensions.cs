using Microsoft.EntityFrameworkCore;
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
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());

        modelBuilder.ApplyConfiguration(new EstablishmentConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new InvitationConfiguration());

        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ClassDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new ClassLanguageConfiguration());
    }

    public static void SeedingDefaultData(this ModelBuilder modelBuilder)
    {
        
    }

}