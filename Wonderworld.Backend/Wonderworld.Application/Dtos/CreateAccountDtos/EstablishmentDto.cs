using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Application.Dtos.CreateAccountDtos;

public class EstablishmentDto
{
    public ICollection<string> Types { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}