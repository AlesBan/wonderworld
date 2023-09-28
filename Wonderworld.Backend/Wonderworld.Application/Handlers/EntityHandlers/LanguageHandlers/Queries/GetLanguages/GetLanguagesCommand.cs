using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguages;

public class GetLanguagesCommand : IRequest<List<Language>>
{
    public IEnumerable<string> LanguageTitles { get; set; } = new List<string>();

}