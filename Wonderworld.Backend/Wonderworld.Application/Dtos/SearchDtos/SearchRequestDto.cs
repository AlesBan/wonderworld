namespace Wonderworld.Application.Dtos.SearchDtos;

public class SearchRequestDto
{
    public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    public IEnumerable<string> Languages { get; set; } = new List<string>();
    public IEnumerable<string> Grades { get; set; } = new List<string>();
    public IEnumerable<string> Countries { get; set; } = new List<string>();
}