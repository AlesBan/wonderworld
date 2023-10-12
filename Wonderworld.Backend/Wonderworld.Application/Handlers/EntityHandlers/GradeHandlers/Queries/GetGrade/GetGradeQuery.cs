using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrade;

public class GetGradeQuery : IRequest<Grade>
{
    public int GradeNumber { get; set; }

    public GetGradeQuery(int gradeNumber)
    {
        GradeNumber = gradeNumber;
    }
}