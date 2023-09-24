using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;

public class GetDisciplinesCommand : IRequest<List<Discipline>>
{
    public IEnumerable<string> DisciplineTitles { get; set; } = new List<string>();
}