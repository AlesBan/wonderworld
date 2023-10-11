using System.ComponentModel.DataAnnotations;

namespace Wonderworld.Application.Dtos.CreateAccountDtos;

public class CreateUserAccountRequestDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public bool IsATeacher { get; set; }
    [Required]
    public bool IsAnExpert { get; set; }
    [Required]
    public string CityLocation { get; set; }
    [Required]
    public string CountryLocation { get; set; }
    [Required]
    public InstitutionDto InstitutionDto { get; set; }
    [Required]
    public ICollection<string> Disciplines { get; set; } = new List<string>();
    [Required]
    public ICollection<string> Languages { get; set; } = new List<string>();
    [Required]
    public string PhotoUrl { get; set; }
}