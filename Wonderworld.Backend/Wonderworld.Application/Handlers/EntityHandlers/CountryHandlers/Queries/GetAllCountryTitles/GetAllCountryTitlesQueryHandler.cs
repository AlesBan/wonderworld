using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetAllCountryTitles;

public class GetAllCountryTitlesQueryHandler: IRequestHandler<GetAllCountryTitlesQuery, List<string>>
{
    private readonly ISharedLessonDbContext _context;

    public GetAllCountryTitlesQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<string>> Handle(GetAllCountryTitlesQuery request, CancellationToken cancellationToken)
    {
        var countryTitles = _context.Countries.Select(c => c.Title).ToList();
        
        return Task.FromResult(countryTitles);
    }
}