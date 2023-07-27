using MediatR;

namespace Wonderworld.Application.Handlers.CountryHandlers.Commands.CreateCountry;

public class CreateCountryCommand : IRequest<Guid>
{
    public string Title { get; set; }
}