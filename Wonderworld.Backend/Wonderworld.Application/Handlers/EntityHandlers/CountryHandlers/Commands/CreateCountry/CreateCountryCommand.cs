using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.CountryHandlers.Commands.CreateCountry;

public class CreateCountryCommand : IRequest<Guid>
{
    public string Title { get; set; }
}