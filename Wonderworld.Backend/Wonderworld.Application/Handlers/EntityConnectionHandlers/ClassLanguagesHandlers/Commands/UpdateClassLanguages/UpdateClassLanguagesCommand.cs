using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.
    UpdateClassLanguages;

public class UpdateClassLanguagesCommand : IRequest
{
    public Guid ClassId { get; set; }
    public IEnumerable<Guid> NewLanguageIds { get; set; }
}