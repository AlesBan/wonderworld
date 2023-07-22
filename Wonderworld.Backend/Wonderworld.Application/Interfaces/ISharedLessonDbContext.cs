using Microsoft.EntityFrameworkCore;
using Wonderworld.Domain.Entities.Communication;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces;

public interface ISharedLessonDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Class> Classes { get; set; }
    DbSet<Discipline> Disciplines { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<InterfaceLanguage> InterfaceLanguages { get; set; }
    DbSet<Appointment> Appointments { get; set; }
    DbSet<Establishment> Establishments { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Country>? Countries { get; set; }
    DbSet<Feedback> Feedbacks { get; set; }
    DbSet<Invitation> Invitations { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}