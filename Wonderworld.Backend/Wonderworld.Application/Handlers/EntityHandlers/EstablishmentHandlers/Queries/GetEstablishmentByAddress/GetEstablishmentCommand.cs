using MediatR;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEstablishmentByAddress;

public class GetEstablishmentCommand : IRequest<Establishment>
{
    public string Address { get; set; }
    public string Title { get; set; } = string.Empty;
    public IEnumerable<EstablishmentType> Types { get; set; } = new List<EstablishmentType>();

}