using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;

public class UpdateProfessionalInfoCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public IEnumerable<string> LanguageTitles { get; set; } = new List<string>();
    public IEnumerable<string> DisciplineTitles { get; set; } = new List<string>();
    public IEnumerable<int> GradeNumbers{ get; set; } = new List<int>();
}