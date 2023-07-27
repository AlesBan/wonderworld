using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommand : IRequest
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public City CityLocation { get; set; }
    public Establishment Establishment { get; set; }
    public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    
    public string PhotoUrl { get; set; }
}