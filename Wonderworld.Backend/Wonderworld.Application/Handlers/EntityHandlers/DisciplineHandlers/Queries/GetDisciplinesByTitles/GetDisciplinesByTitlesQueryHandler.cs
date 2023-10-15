using MediatR;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplinesByTitles;

public class GetDisciplinesByTitlesQueryHandler : IRequestHandler<GetDisciplinesByTitlesQuery, List<Discipline>>
{
    private readonly ISharedLessonDbContext _context;

    public GetDisciplinesByTitlesQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Discipline>> Handle(GetDisciplinesByTitlesQuery request, CancellationToken cancellationToken)
    {
        var requiredDisciplines = request.DisciplineTitles;
        var disciplines = _context.Disciplines
            .Where(d =>
                requiredDisciplines.Contains(d.Title));

        return Task.FromResult(disciplines.ToList());
    }
}