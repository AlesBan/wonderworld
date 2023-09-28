using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    UpdateUserDisciplines;

public class UpdateUserDisciplinesCommand : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> NewDisciplines { get; set; } = new List<Guid>();
}