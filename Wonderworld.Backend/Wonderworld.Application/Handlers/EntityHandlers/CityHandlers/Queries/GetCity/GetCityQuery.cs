using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Queries.GetCity;

public class GetCityQuery : IRequest<City>
{
    public string Title { get; set; }
    public Guid CountryId { get; set; }
}