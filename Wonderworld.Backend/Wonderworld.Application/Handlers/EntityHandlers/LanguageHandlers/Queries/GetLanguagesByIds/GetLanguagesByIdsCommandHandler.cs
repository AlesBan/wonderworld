using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByIds;

public class GetLanguagesByIdsCommandHandler : IRequestHandler<GetLanguagesByIdsCommand, List<Language>>
{
    private readonly ISharedLessonDbContext _context;

    public GetLanguagesByIdsCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Language>> Handle(GetLanguagesByIdsCommand request, CancellationToken cancellationToken)
    {
        var requestLanguageIds = request.LanguageIds;
        var languages = _context.Languages.Where(l =>
            requestLanguageIds.Contains(l.LanguageId));
        
        return Task.FromResult(languages.ToList());
    }
}