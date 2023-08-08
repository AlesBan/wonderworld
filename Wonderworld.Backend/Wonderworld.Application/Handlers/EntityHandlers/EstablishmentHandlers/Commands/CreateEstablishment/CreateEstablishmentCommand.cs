using MediatR;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommand : IRequest<Guid>
{
    public string Type { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
}