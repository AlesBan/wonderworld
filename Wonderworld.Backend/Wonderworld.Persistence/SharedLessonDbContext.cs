using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

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
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Establishment> Establishments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserDiscipline> UserDisciplines { get; set; }
    public DbSet<UserGrade> UserGrades { get; set; }
    public DbSet<UserLanguage> UserLanguages { get; set; }
    
    public DbSet<ClassLanguage> ClassLanguages { get; set; }
    public DbSet<ClassDiscipline> ClassDisciplines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AppendConfigurations();

        modelBuilder.SeedingDefaultData();
    }
}