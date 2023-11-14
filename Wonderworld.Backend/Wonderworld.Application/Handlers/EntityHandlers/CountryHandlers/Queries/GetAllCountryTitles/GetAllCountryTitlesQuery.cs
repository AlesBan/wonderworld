using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetAllCountryTitles;

public class GetAllCountryTitlesQuery : IRequest<List<string>>
{
}