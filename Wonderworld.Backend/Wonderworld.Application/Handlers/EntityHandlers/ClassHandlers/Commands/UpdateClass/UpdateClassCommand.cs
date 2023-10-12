using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;

public class UpdateClassCommand : IRequest<Class>
{
    public Guid ClassId { get; set; }
    public string Title { get; set; }
    public int GradeNumber { get; set; }
    public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public string? PhotoUrl { get; set; }
}