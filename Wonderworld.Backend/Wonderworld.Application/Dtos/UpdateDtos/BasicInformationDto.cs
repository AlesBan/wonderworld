using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Dtos.UpdateDtos;

public class BasicInformationDto
{
    public ICollection<Language> Languages { get; set; } = new List<Language>();
    public City CityLocation { get; set; } = new();
    public ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}