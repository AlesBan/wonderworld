using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;

public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, List<Grade>>
{
    private readonly ISharedLessonDbContext _context;

    public GetGradesQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<List<Grade>> Handle(GetGradesQuery request, CancellationToken cancellationToken)
    {
        var requiredGrades = request.GradeNumbers;
        var grades = await _context.Grades
            .Where(g =>
                requiredGrades.Contains(g.GradeNumber))
            .ToListAsync(cancellationToken: cancellationToken);

        return await Task.FromResult(grades);
    }
}