using MediatR;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Queries.GetEstablishment;

public class GetInstitutionQuery : IRequest<Institution>
{
    public string Address { get; set; }
    public string InstitutionTitle { get; set; } = string.Empty;
    public IEnumerable<string> Types { get; set; } = new List<string>();
}