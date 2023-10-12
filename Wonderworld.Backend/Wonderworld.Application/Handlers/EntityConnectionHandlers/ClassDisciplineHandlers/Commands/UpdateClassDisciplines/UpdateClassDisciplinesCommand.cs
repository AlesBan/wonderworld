using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.
    UpdateClassDisciplines;

public class UpdateClassDisciplinesCommand : IRequest
{
    public Guid ClassId { get; set; }
    public IEnumerable<Guid> NewDisciplineIds { get; set; }
}