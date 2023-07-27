using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.CityHandlers.Commands.DeleteCity;

public class DeleteCityCommand : IRequest
{
    public Guid CityId { get; set; }
}