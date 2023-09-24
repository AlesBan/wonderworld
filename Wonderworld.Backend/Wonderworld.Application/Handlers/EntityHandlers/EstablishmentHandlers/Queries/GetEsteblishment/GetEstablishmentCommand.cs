using MediatR;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Queries.GetEsteblishment;

public class GetEstablishmentCommand : IRequest<Establishment>
{
    public Country Country { get; set; }
    public City City { get; set; }
    public string Title { get; set; }
}