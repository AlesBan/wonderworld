using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.
    GetDisciplinesByIds;

public class GetDisciplinesByIdsCommand : IRequest<List<Discipline>>
{
    public IEnumerable<Guid> DisciplineIds { get; set; }

    public GetDisciplinesByIdsCommand(IEnumerable<Guid> disciplineIds)
    {
        DisciplineIds = disciplineIds;
    }
}