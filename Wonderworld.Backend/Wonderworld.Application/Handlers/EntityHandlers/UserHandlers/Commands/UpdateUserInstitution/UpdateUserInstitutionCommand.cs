using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserInstitution;

public class UpdateUserInstitutionCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public string InstitutionTitle { get; set; }
    public string Address { get; set; }
    public IEnumerable<string> Types { get; set; } = new List<string>();

}