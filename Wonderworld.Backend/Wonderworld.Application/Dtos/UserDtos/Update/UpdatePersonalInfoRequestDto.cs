namespace Wonderworld.Application.Dtos.UserDtos.UpdateDtos;

public class UpdatePersonalInfoRequestDto
{
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string CityTitle { get; set; } = string.Empty;
    public string CountryTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}