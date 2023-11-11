namespace Wonderworld.Application.Dtos.SearchDtos;

public class SearchCommandDto
{
    public Guid UserId { get; init; }
    public IEnumerable<string> Disciplines { get; init; } = new List<string>();
    public IEnumerable<string> Languages { get; init; } = new List<string>();
    public IEnumerable<string> Grades { get; init; } = new List<string>();
    public IEnumerable<string> Countries { get; init; } = new List<string>();
}