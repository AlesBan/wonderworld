using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;

public class UpdateUserGradesCommand : IRequest
{
    public Guid UserId { get; set; }
    public ICollection<Guid> NewGradeIds { get; set; } = new List<Guid>();
}