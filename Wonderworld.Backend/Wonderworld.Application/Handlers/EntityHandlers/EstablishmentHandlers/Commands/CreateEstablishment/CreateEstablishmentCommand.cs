using MediatR;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommand : IRequest<Institution>
{
    public IEnumerable<InstitutionType> Types { get; set; } = new List<InstitutionType>();
    public string Title { get; set; }
    public string Address { get; set; }
}