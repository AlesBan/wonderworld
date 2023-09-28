using MediatR;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommand : IRequest<Establishment>
{
    public IEnumerable<EstablishmentType> Types { get; set; } = new List<EstablishmentType>();
    public string Title { get; set; }
    public string Address { get; set; }
}