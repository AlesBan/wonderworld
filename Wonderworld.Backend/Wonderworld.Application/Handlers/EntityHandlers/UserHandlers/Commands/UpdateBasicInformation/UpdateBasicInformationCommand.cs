using MediatR;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateBasicInformation;

public class UpdateBasicInformationCommand : IRequest
{
    public Guid UserId { get; set; }
    public City CityLocation { get; set; }
    public ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();
    public ICollection<UserGrade> UserGrades { get; set; } = new List<UserGrade>();
    public ICollection<UserDiscipline> UserDisciplines { get; set; } = new List<UserDiscipline>();
}