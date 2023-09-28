using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;

public class CreateCityCommand : IRequest<City>
{
    public string Title { get; set; }
    public Guid CountryId { get; set; }
}