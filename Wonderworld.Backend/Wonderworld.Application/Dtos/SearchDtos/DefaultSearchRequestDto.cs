using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Dtos.SearchDtos;

public class DefaultSearchRequestDto
{
    public IEnumerable<Discipline> Disciplines { get; init; } = new List<Discipline>();
    public Country Country { get; init; } = new();
}