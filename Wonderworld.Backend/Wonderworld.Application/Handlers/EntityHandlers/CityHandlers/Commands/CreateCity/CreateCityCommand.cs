using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.CreateCity;

public class CreateCityCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public Country Country { get; set; }
    
}