using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommand : IRequest
{
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public City CityLocation { get; set; }
    public Establishment Establishment { get; set; }
    public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public string PhotoUrl { get; set; }
}