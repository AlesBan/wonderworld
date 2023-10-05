using MediatR;
using Wonderworld.Domain.Entities.Job;
using EstablishmentType = Wonderworld.Domain.Enums.EntityTypes.EstablishmentType;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEstablishmentByAddress;

public class GetEstablishmentCommand : IRequest<Institution>
{
    public string Address { get; set; }
    public string Title { get; set; } = string.Empty;
    public IEnumerable<Guid> Types { get; set; } = new List<Guid>();

}