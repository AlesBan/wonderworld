using MediatR;

namespace Wonderworld.Application.Handlers.CityHandlers.Commands.DeleteCity;

public class DeleteCityCommand : IRequest
{
    public Guid CityId { get; set; }
}