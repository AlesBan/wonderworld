using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;

public class UpdateProfessionalInfoCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public IEnumerable<string> Languages { get; set; } = new List<string>();
    public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    public IEnumerable<string> Grades { get; set; } = new List<string>();
}