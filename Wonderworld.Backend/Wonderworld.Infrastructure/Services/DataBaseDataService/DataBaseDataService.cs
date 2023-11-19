using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetAllCountryTitles;

namespace Wonderworld.Infrastructure.Services.DataBaseDataService;

public class DataBaseDataService : IDataBaseDataService
{
    public async Task<ExistingCountriesDto> GetAllCounties(IMediator mediator)
    {
        var result = await mediator.Send(new GetAllCountryTitlesQuery());

        return new ExistingCountriesDto { CoutryTitles = result };
    }
}