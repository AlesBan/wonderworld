using MediatR;

namespace Wonderworld.Application.Handlers.LanguageHandlers.Commands.CreateLanguage;

public class CreateLanguageCommand : IRequest<Guid>
{
    public string Title { get; set; }
}