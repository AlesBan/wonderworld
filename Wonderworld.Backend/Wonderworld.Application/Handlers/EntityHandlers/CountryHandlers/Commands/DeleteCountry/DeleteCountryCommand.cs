using MediatR;

namespace Wonderworld.Application.Handlers.CountryHandlers.Commands.DeleteCountry;

public class DeleteCountryCommand : IRequest
{
    public Guid CountryId { get; set; }
}