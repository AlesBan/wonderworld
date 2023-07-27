using Microsoft.EntityFrameworkCore;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Interfaces;

public interface ISharedLessonDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Grade> Grades { get; set; }
    DbSet<Class> Classes { get; set; }
    DbSet<Discipline> Disciplines { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<Establishment> Establishments { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Feedback> Feedbacks { get; set; }
    DbSet<Invitation> Invitations { get; set; }
    DbSet<UserRole> UserRoles { get; set; }
    DbSet<UserDiscipline> UserDisciplines { get; set; }
    DbSet<UserGrade> UserGrades { get; set; }
    DbSet<UserLanguage> UserLanguages { get; set; }

    DbSet<ClassLanguage> ClassLanguages { get; set; }
    DbSet<ClassDiscipline> ClassDisciplines { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}