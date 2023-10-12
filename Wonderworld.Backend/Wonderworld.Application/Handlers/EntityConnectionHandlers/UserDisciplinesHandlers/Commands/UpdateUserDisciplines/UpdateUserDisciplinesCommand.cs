using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.
    UpdateUserDisciplines;

public class UpdateUserDisciplinesCommand : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> NewDisciplineIds { get; set; } = new List<Guid>();
}