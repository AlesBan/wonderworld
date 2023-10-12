using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;

public class CreateClassCommand : IRequest<Class>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int GradeNumber { get; set; }
    public IEnumerable<Discipline> Disciplines { get; set; } = new List<Discipline>();
    public IEnumerable<Language> Languages { get; set; } = new List<Language>();
    public string? PhotoUrl { get; set; }
}