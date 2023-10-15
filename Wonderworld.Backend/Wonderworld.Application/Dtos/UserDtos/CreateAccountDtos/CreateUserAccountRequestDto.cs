using System.ComponentModel.DataAnnotations;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.InstitutionDtos;

namespace Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;

public class CreateUserAccountRequestDto
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public bool IsATeacher { get; set; }
    [Required] public bool IsAnExpert { get; set; }
    [Required] public string CityLocation { get; set; }
    [Required] public string CountryLocation { get; set; }
    [Required] public InstitutionDto InstitutionDto { get; set; }
    [Required] public IEnumerable<string> Disciplines { get; set; } = new List<string>();
    [Required] public IEnumerable<string> Languages { get; set; } = new List<string>();
    [Required] public IEnumerable<int> Grades { get; set; } = new List<int>();
    [Required] public string PhotoUrl { get; set; }
}