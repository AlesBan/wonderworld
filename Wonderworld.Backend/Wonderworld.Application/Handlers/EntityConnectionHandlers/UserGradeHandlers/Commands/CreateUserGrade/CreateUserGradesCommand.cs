using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;

public class CreateUserGradesCommand : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> GradeIds { get; set; }
}