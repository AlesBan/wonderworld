using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Queries.GetAllCountryTitles;

namespace Wonderworld.API.Controllers;

[Produces("application/json")]
public class LocationController : BaseController
{
    [HttpGet("all-country-locations")]
    public async Task<CountryLocationsDto> GetAllCountryLocations()
    {
        var result = await Mediator.Send(new GetAllCountryTitlesQuery());

        return new CountryLocationsDto { CoutryTitles = result };
    }
}