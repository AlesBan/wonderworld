using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetAllCountryTitles;

namespace Wonderworld.Infrastructure.Services.SearchDataService;

public class SearchDataService : ISearchDataService
{
    public async Task<ExistingCountriesDto> GetAllCounties(IMediator mediator)
    {
        var result = await mediator.Send(new GetAllCountryTitlesQuery());

        return new ExistingCountriesDto { CoutryTitles = result };
    }
}