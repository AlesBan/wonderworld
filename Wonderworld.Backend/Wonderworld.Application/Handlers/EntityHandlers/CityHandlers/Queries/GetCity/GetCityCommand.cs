using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;

public class GetCityCommand : IRequest<City>
{
    public string Title { get; set; }
    public string CountryTitle { get; set; }
}