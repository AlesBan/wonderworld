using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Attributes;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;

namespace Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;

public class CreateUserAccountRequestDto
{
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;

    [Required]
    [AtLeastOneOfPositionTrue("IsATeacher", "IsAnExpert")]
    public bool IsATeacher { get; set; }

    [Required]
    [AtLeastOneOfPositionTrue("IsATeacher", "IsAnExpert")]
    public bool IsAnExpert { get; set; }
    [Required] public string CityLocation { get; set; } = string.Empty;
    [Required] public string CountryLocation { get; set; } = string.Empty;
    [Required] public InstitutionDto InstitutionDto { get; set; }
    [Required] public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    [Required] public IEnumerable<string> Languages { get; set; } = new List<string>();
    [Required] public IEnumerable<int> Grades { get; set; } = new List<int>();
    [Required] public string PhotoUrl { get; set; } = string.Empty;
}