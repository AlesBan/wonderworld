using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.UserDtos;

namespace Wonderworld.Application.Dtos.SearchDtos;

public class SearchResponseDto
{
    public IEnumerable<UserProfileDto> TeacherProfiles { get; init; } = new List<UserProfileDto>();
    public IEnumerable<UserProfileDto> ExpertProfiles { get; init; } = new List<UserProfileDto>();
    public IEnumerable<ClassProfileDto> ClassProfiles { get; init; } = new List<ClassProfileDto>();
}