namespace Wonderworld.Application.Dtos.UserDtos.UpdateDtos;

public class UpdateProfessionalInfoRequestDto
{
    public IEnumerable<string> Languages { get; set; } = new List<string>();
    public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    public IEnumerable<int> Grades { get; set; } = new List<int>();
}