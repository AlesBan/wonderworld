using MediatR;
using Wonderworld.Domain.Entities.Education;

namespace Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries;

public class GetGradesQuery : IRequest<List<Grade>>
{
    public IEnumerable<int> GradeNumbers { get; set; } = new List<int>();
}