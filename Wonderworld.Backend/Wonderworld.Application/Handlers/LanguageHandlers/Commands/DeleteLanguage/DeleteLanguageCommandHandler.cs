using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.LanguageHandlers.Commands.DeleteLanguage;

public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteLanguageCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
    {
        var language = _context.Languages!
            .FirstOrDefault(t =>
                t.LanguageId == request.LanguageId);

        if (language == null)
        {
            throw new NotFoundException(nameof(Language), request.LanguageId);
        }

        await RemoveLanguage(language, cancellationToken);
        return Unit.Value;
    }

    private async Task RemoveLanguage(Language language, CancellationToken cancellationToken)
    {
        _context.Languages!.Remove(language);
        await _context.SaveChangesAsync(cancellationToken);
    }
}