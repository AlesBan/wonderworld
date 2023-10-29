using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Dtos.SearchDtos;

public class DefaultSearchRequestDto
{
    public IEnumerable<Guid> DisciplineIds { get; init; } = new List<Guid>();
    public Guid CountryId { get; init; } = new();
}