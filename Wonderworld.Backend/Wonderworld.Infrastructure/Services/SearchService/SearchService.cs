using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Helpers;

namespace Wonderworld.Infrastructure.Services.SearchService;

public class SearchService : ISearchService
{
    private readonly IUserHelper _userHelper;

    public SearchService(IUserHelper userHelper)
    {
        _userHelper = userHelper;
    }

    public async Task<SearchResponseDto> GetTeacherAndClassProfiles(SearchRequestDto searchRequest, IMediator mediator)
    {
        var userList = await GetUserListBySearchRequest(searchRequest, mediator);
        var searchResponseDto = await GetSearchResponseDto(userList, searchRequest.Disciplines);
        return searchResponseDto;
    }

    private static async Task<IEnumerable<User>> GetUserListBySearchRequest(SearchRequestDto searchRequest,
        IMediator mediator)
    {
        var query = new GetUserListBySearchRequestCommand
        {
            SearchRequest = searchRequest
        };

        var userList = (await mediator.Send(query)).ToList();

        return userList;
    }

    private async Task<SearchResponseDto> GetSearchResponseDto(IEnumerable<User> userList,
        IEnumerable<string> languages)
    {
        var userProfileList = await GetUserProfileList(userList);
        var teacherProfiles = GetProfiles(userProfileList, isTeacher: true);
        var expertProfiles = GetProfiles(userProfileList, isTeacher: false);
        var classProfiles = GetClassProfiles(teacherProfiles, languages);

        return new SearchResponseDto
        {
            TeacherProfiles = teacherProfiles,
            ExpertProfiles = expertProfiles,
            ClassProfiles = classProfiles
        };
    }

    private async Task<IEnumerable<UserProfileDto>> GetUserProfileList(IEnumerable<User> userList)
    {
        var userProfileDtos = await Task.WhenAll(userList
            .Select(u =>
                _userHelper.MapUserToUserProfileDto(u)));
        return userProfileDtos;
    }

    private static IEnumerable<UserProfileDto> GetProfiles(IEnumerable<UserProfileDto> userProfileList, bool isTeacher)
    {
        return userProfileList
            .Where(up => up.IsATeacher == isTeacher);
    }

    private static IEnumerable<ClassProfileDto> GetClassProfiles(IEnumerable<UserProfileDto> teacherProfiles,
        IEnumerable<string> disciplines)
    {
        return teacherProfiles
            .SelectMany(tp => tp.ClasseDtos)
            .Where(c => c.Disciplines.Intersect(disciplines,
                StringComparer.OrdinalIgnoreCase).Any())
            .Select(c => new ClassProfileDto
            {
                ClassId = c.ClassId,
                Title = c.Title,
                UserFullName = c.UserFullName,
                UserRating = c.UserRating,
                Grade = c.Grade,
                Languages = c.Languages,
                Disciplines = c.Disciplines,
                PhotoUrl = c.PhotoUrl!
            });
    }
}