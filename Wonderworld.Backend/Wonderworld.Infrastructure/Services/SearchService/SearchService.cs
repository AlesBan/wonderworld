using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Infrastructure.Helpers;

namespace Wonderworld.Infrastructure.Services.SearchService;

public class SearchService : ISearchService
{
    private readonly IMapper _mapper;

    public SearchService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<SearchResponseDto> GetTeacherAndClassProfilesDependingOnSearchRequest(
        SearchRequestDto searchRequest, IMediator mediator)
    {
        var userProfileList = (await UserHelper.GetUserProfilesBySearchRequest(searchRequest, mediator)).ToList();

        var classProfileList = (await GetClassProfiles(userProfileList)).ToList();

        var responseDto = CreateSearchResponseDto(userProfileList, classProfileList);

        return responseDto;
    }

    private Task<IEnumerable<ClassProfileDto>> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        var classList = userProfileList.Select(up => up.ClasseDtos).ToList();

        var classProfileList = classList.Select(cp =>
                _mapper.Map<ClassProfileDto>(cp))
            .ToList();

        return Task.FromResult<IEnumerable<ClassProfileDto>>(classProfileList);
    }

    private static SearchResponseDto CreateSearchResponseDto(IReadOnlyCollection<UserProfileDto> userProfileList,
        IEnumerable<ClassProfileDto> classProfileList)
    {
        var responseDto = new SearchResponseDto
        {
            TeacherProfiles = userProfileList.Where(u =>
                    u.IsATeacher)
                .ToList(),
            ExpertProfiles = userProfileList.Where(u =>
                u.IsAnExpert &&
                u.IsATeacher == false),
            ClassProfiles = classProfileList
        };

        return responseDto;
    }
}