using MediatR;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;

public class UpdateClassCommand : IRequest
{
    public Class Class { get; set; }
    
    public string Title { get; set; }
    public Grade Grade { get; set; }
    public int Age { get; set; }

    public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public string PhotoUrl { get; set; }
}