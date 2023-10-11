using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Dtos.UpdateDtos;

public class UpdateProfessionalInfoRequestDto
{
    public IEnumerable<string> Languages { get; set; } = new List<string>();
    public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    public IEnumerable<int> Grades { get; set; } = new List<int>();
}