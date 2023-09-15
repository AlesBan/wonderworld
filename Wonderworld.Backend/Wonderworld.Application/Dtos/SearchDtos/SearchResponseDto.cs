using Wonderworld.Application.Dtos.ProfileDtos;

namespace Wonderworld.Application.Dtos.SearchDtos;

public class SearchResponseDto
{
    public IEnumerable<UserProfileDto> TeacherProfiles { get; set; } = new List<UserProfileDto>();
    public IEnumerable<UserProfileDto> ExpertProfiles { get; set; } = new List<UserProfileDto>();
    
    public IEnumerable<ClassProfileDto> ClassProfiles { get; set; } = new List<ClassProfileDto>();
}