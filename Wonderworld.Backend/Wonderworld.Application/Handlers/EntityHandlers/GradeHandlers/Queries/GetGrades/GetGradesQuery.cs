using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;

public class GetGradesQuery : IRequest<List<Grade>>
{
    public IEnumerable<int> GradeNumbers { get; set; }

    public GetGradesQuery(IEnumerable<int> gradeNumbers)
    {
        GradeNumbers = gradeNumbers;
    }
}