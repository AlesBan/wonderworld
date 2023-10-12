using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;

public class GetDisciplinesQuery : IRequest<List<Discipline>>
{
    public IEnumerable<string> DisciplineTitles { get; set; }
    
    public GetDisciplinesQuery(IEnumerable<string> disciplineTitles)
    {
        DisciplineTitles = disciplineTitles;
    }
}