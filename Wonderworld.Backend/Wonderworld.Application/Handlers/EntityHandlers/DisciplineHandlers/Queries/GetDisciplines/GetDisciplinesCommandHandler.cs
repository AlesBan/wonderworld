using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;

public class GetDisciplinesCommandHandler : IRequestHandler<GetDisciplinesCommand, List<Discipline>>
{
    private readonly ISharedLessonDbContext _context;

    public GetDisciplinesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<List<Discipline>> Handle(GetDisciplinesCommand request, CancellationToken cancellationToken)
    {
        var requiredDisciplines = request.DisciplineTitles;
        var disciplines = _context.Disciplines
            .Where(d =>
                requiredDisciplines.Contains(d.Title));

        return Task.FromResult(disciplines.ToList());
    }
}