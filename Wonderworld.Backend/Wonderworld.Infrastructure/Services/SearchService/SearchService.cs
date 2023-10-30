using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Helpers;

namespace Wonderworld.Infrastructure.Services.SearchService;

public class SearchService : ISearchService
{
    private readonly IMapper _mapper;
    private readonly IUserHelper _userHelper;

    public SearchService(IMapper mapper, IUserHelper userHelper)
    {
        _mapper = mapper;
        _userHelper = userHelper;
    }

    public async Task<SearchResponseDto> GetTeacherAndClassProfilesDependingOnSearchRequest(
        SearchRequestDto searchRequest, IMediator mediator)
    {
        var userProfileList = (await GetUserProfilesBySearchRequest(searchRequest, mediator)).ToList();

        var classProfileList = (await GetClassProfiles(userProfileList)).ToList();

        var responseDto = CreateSearchResponseDto(userProfileList, classProfileList);

        return responseDto;
    }

    private async Task<IEnumerable<UserProfileDto>> GetUserProfilesBySearchRequest(
        SearchRequestDto searchRequest,
        IMediator mediator)
    {
        var userList = await GetUserListBySearchRequest(searchRequest, mediator);

        var userProfileDtosTasks = userList.Select(async u =>
            await _userHelper.MapUserToUserProfileDto(u));

        var userProfileDtos = await Task.WhenAll(userProfileDtosTasks);
        return userProfileDtos;
    }

    private async Task<IEnumerable<User>> GetUserListBySearchRequest(
        SearchRequestDto searchRequest, IMediator mediator)
    {
        var query = new GetUserListBySearchRequestCommand()
        {
            SearchRequest = searchRequest
        };

        var userList = (await mediator.Send(query)).ToList();

        return userList;
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

    private Task<IEnumerable<ClassProfileDto>> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        var classList = userProfileList.Select(up => up.ClasseDtos).ToList();

        var classProfileList = classList.Select(cp =>
                _mapper.Map<ClassProfileDto>(cp))
            .ToList();

        return Task.FromResult<IEnumerable<ClassProfileDto>>(classProfileList);
    }
}