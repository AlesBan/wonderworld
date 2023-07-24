using MediatR;

namespace Wonderworld.Application.Handlers.LanguageHandlers.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest
{
    public Guid LanguageId { get; set; }
}