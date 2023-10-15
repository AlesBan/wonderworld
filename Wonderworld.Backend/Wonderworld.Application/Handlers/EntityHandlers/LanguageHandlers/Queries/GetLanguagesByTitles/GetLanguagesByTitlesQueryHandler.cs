using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;

public class GetLanguagesByTitlesQueryHandler: IRequestHandler<GetLanguagesByTitlesQuery, List<Language>>
{
    private readonly ISharedLessonDbContext _context;

    public GetLanguagesByTitlesQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Language>> Handle(GetLanguagesByTitlesQuery request, CancellationToken cancellationToken)
    {
        var requestLanguageTitles = request.LanguageTitles;
        var languages = _context.Languages.Where(l =>
            requestLanguageTitles.Contains(l.Title));
        
        return Task.FromResult(languages.ToList());
    }
}