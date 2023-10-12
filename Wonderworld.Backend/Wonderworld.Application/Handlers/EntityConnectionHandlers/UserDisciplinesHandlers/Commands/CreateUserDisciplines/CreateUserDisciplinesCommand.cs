using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;

public class CreateUserDisciplinesCommand : IRequest
{
    public Guid UserId { get; set; }
    public IEnumerable<Guid> DisciplineIds { get; set; }
}