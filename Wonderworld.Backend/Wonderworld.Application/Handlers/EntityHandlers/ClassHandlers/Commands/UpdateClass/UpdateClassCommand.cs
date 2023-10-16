using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;

public class UpdateClassCommand : IRequest<Class>
{
    public Guid ClassId { get; set; }
    public string Title { get; set; }
    public int GradeNumber { get; set; }
    public IEnumerable<string> DisciplineTitles { get; set; } = new List<string>();
    public IEnumerable<string> LanguageTitles { get; set; } = new List<string>();
    public string? PhotoUrl { get; set; }
}