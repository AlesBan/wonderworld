namespace Wonderworld.Application.Dtos.SearchDtos;

public class DefaultSearchCommandDto
{
    public Guid UserId { get; init; }
    public IEnumerable<Guid> DisciplineIds { get; init; } = new List<Guid>();
    public Guid CountryId { get; init; }
}