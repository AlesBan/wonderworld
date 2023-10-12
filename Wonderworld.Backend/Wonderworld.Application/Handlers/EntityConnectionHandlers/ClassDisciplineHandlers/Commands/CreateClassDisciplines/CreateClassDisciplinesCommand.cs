using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.
    CreateClassDisciplines;

public class CreateClassDisciplinesCommand : IRequest
{
    public Guid ClassId { get; set; }
    public IEnumerable<Guid> DisciplineIds { get; set; }
}