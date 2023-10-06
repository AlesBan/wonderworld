using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Dtos.CreateAccountDtos;

public class InstitutionDto
{
    public IEnumerable<string> Types { get; set; } = new List<string>();
    public string Address { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}