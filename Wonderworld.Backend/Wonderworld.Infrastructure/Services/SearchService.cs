using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnSearchQuery;
using Wonderworld.Application.Interfaces.Services;

namespace Wonderworld.Infrastructure.Services;

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
        var queryToGetUserProfiles = CreateGetUserProfileListDependingOnSearchQueryCommand(searchRequest);

        var userProfileList = (await GetUserProfiles(queryToGetUserProfiles, mediator)).ToList();

        var classProfileList = (await GetClassProfiles(userProfileList)).ToList();

        var responseDto = CreateSearchResponseDto(userProfileList, classProfileList);

        return responseDto;
    }

    private Task<IEnumerable<ClassProfileDto>> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        var classList = userProfileList.Select(up => up.Classes).ToList();

        var classProfileList = classList.Select(cp =>
                _mapper.Map<ClassProfileDto>(cp))
            .ToList();

        return Task.FromResult<IEnumerable<ClassProfileDto>>(classProfileList);
    }

    private static async Task<IEnumerable<UserProfileDto>> GetUserProfiles(
        GetUserProfileListDependingOnSearchQueryCommand query, IMediator mediator)
    {
        var userProfileList = (await mediator.Send(query)).ToList();

        return userProfileList;
    }

    private static GetUserProfileListDependingOnSearchQueryCommand
        CreateGetUserProfileListDependingOnSearchQueryCommand(
            SearchRequestDto searchRequest)
    {
        return new GetUserProfileListDependingOnSearchQueryCommand()
        {
            SearchRequest = searchRequest
        };
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