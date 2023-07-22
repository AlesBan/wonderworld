using MediatR;

namespace Wonderworld.Application.Handlers.CityHandlers.Commands.CreateCity;

public class CreateCityCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public Guid CountryId { get; set; }
}