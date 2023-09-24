using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;

public class GetLanguagesCommandHandler: IRequestHandler<GetLanguagesCommand, List<Language>>
{
    private readonly ISharedLessonDbContext _context;

    public GetLanguagesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Language>> Handle(GetLanguagesCommand request, CancellationToken cancellationToken)
    {
        var requestLanguageTitles = request.LanguageTitles;
        var languages = _context.Languages.Where(l =>
            requestLanguageTitles.Contains(l.Title));
        
        return Task.FromResult(languages.ToList());
    }
}