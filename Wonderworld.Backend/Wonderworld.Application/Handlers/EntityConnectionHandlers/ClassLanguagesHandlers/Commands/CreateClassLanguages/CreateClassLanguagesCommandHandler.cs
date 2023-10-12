using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.CreateClassLanguages;

public class CreateClassLanguagesCommandHandler: IRequestHandler<CreateClassLanguagesCommand, Unit>
{
    private readonly ISharedLessonDbContext _context;

    public CreateClassLanguagesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateClassLanguagesCommand request, CancellationToken cancellationToken)
    {
        var classLanguages = request.LanguageIds
            .Select(langId =>
                new ClassLanguage()
                {
                    ClassId = request.ClassId,
                    LanguageId = langId
                });

        await _context.ClassLanguages
            .AddRangeAsync(classLanguages, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}