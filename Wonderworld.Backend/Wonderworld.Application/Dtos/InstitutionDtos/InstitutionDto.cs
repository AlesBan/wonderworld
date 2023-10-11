using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Dtos.CreateAccountDtos;

public class InstitutionDto
{
    public List<string> Types { get; set; }
    public string Address { get; set; }
    public string Title { get; set; }
}