using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Persistence.EntityTypeConfiguration;
using Wonderworld.Persistence.EntityTypeConfiguration.Communication;
using Wonderworld.Persistence.EntityTypeConfiguration.Education;
using Wonderworld.Persistence.EntityTypeConfiguration.Interface;
using Wonderworld.Persistence.EntityTypeConfiguration.Job;
using Wonderworld.Persistence.EntityTypeConfiguration.Location;
using Wonderworld.Persistence.EntityTypeConfiguration.Main;
using Wonderworld.Persistence.EntityTypeConnectionsConfiguration;

namespace Wonderworld.Persistence;

public class SharedLessonDbContext : DbContext, ISharedLessonDbContext
{
    public SharedLessonDbContext(DbContextOptions options) :
        base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<InterfaceLanguage> InterfaceLanguages { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Establishment> Establishments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Invitation> Invitations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AppendConfigurations();

        modelBuilder.SeedingDefaultData();
    }
}