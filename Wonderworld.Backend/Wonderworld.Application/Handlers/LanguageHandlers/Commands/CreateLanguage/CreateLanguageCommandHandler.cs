using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.LanguageHandlers.Commands.CreateLanguage;

public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateLanguageCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        var language = new Language()
        {
            Title = request.Title
        };
        await AddLanguage(language, cancellationToken);
        return await Task.FromResult(language.LanguageId);
    }

    private async Task AddLanguage(Language language, CancellationToken cancellationToken)
    {
        await _context.Languages.AddAsync(language, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}