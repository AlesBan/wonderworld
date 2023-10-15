using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;

public class GetLanguagesByTitlesQuery : IRequest<List<Language>>
{
    public IEnumerable<string> LanguageTitles { get; set; }

    public GetLanguagesByTitlesQuery(IEnumerable<string> languageTitles)
    {
        LanguageTitles = languageTitles;
    }
}