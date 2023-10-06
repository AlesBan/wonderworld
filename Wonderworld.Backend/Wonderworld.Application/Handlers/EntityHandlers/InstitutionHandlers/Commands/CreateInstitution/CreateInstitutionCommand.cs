using MediatR;
using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.CreateInstitution;

public class CreateInstitutionCommand : IRequest<Institution>
{
    public IEnumerable<string> Types { get; set; } = new List<string>();
    public string Title { get; set; }
    public string Address { get; set; }
}