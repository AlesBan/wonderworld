using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;

public class GetDisciplinesByTitlesQuery : IRequest<List<Discipline>>
{
    public IEnumerable<string> DisciplineTitles { get; set; }
    
    public GetDisciplinesByTitlesQuery(IEnumerable<string> disciplineTitles)
    {
        DisciplineTitles = disciplineTitles;
    }
}