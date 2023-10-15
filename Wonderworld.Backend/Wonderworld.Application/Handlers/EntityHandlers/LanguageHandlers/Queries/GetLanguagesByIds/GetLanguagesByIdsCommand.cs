using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByIds;

public class GetLanguagesByIdsCommand : IRequest<List<Language>>
{
    public IEnumerable<Guid> LanguageIds { get; set; }

    public GetLanguagesByIdsCommand(IEnumerable<Guid> languageIds)
    {
        LanguageIds = languageIds;
    }
}