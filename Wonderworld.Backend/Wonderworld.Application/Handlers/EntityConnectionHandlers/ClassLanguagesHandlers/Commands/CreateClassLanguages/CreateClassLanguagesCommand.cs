using MediatR;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.
    CreateClassLanguages;

public class CreateClassLanguagesCommand : IRequest
{
    public Guid ClassId { get; set; }
    public IEnumerable<Guid> LanguageIds { get; set; }
}