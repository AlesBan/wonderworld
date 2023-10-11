namespace Wonderworld.Application.Dtos.ClassDtos;

public class UpdateClassRequestDto
{
    public Guid ClassId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Grade { get; set; }
    public string? PhotoUrl { get; set; } = string.Empty;
    public IEnumerable<string> LanguageTitles { get; set; } = new List<string>();
    public IEnumerable<string> DisciplineTitles { get; set; } = new List<string>();
}