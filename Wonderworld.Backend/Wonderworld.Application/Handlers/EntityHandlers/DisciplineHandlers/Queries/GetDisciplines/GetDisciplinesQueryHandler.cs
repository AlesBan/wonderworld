using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;

public class GetDisciplinesQueryHandler : IRequestHandler<GetDisciplinesQuery, List<Discipline>>
{
    private readonly ISharedLessonDbContext _context;

    public GetDisciplinesQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Discipline>> Handle(GetDisciplinesQuery request, CancellationToken cancellationToken)
    {
        var requiredDisciplines = request.DisciplineTitles;
        var disciplines = _context.Disciplines
            .Where(d =>
                requiredDisciplines.Contains(d.Title));

        return Task.FromResult(disciplines.ToList());
    }
}