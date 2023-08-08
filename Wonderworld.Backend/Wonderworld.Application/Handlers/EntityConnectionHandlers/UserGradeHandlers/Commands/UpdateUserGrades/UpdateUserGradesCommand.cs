using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;

public class UpdateUserGradesCommand : IRequest
{
    public User User { get; set; }
    public ICollection<Grade> NewGrades { get; set; } = new List<Grade>();
}