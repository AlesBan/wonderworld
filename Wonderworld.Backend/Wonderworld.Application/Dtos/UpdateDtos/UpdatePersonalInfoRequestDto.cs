namespace Wonderworld.Application.Dtos.UpdateDtos;

public class UpdatePersonalInfoRequestDto
{
    public bool IsATeacher { get; set; }
    public bool IsAnExpert { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}