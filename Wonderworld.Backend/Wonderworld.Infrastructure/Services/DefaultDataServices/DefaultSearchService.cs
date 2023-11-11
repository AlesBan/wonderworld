using AutoMapper;
using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;
using Wonderworld.Application.Helpers.UserHelper;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public class DefaultSearchService : IDefaultSearchService
{
    private readonly IUserHelper _userHelper;

    public DefaultSearchService(IUserHelper userHelper)
    {
        _userHelper = userHelper;
    }

    public async Task<DefaultSearchResponseDto> GetDefaultTeacherAndClassProfiles(Guid userId, IMediator mediator)
    {
        var user = await GetUserById(userId, mediator);
        var searchRequest = await CreateDefaultSearchRequestDto(user);
        var userList = await GetUserListByDefaultSearchRequest(searchRequest, mediator);
        var defaultSearchResponseDto = await GetDefaultSearchResponseDto(user, userList);
        return defaultSearchResponseDto;
    }

    private async Task<User> GetUserById(Guid userId, IMediator mediator)
    {
        return await _userHelper.GetUserById(userId, mediator);
    }

    private static Task<DefaultSearchCommandDto> CreateDefaultSearchRequestDto(User user)
    {
        var userDisciplineIds = user.UserDisciplines.Select(ud => ud.DisciplineId).ToList();
        var userCountryId = user.CountryId ?? Guid.Empty;

        return Task.FromResult(new DefaultSearchCommandDto
        {
            UserId = user.UserId,
            DisciplineIds = userDisciplineIds,
            CountryId = userCountryId
        });
    }

    private static async Task<IEnumerable<User>> GetUserListByDefaultSearchRequest(
        DefaultSearchCommandDto searchRequest,
        IMediator mediator)
    {
        var query = new GetUserListByDefaultSearchRequestCommand
        {
            SearchRequest = searchRequest
        };

        var userList = (await mediator.Send(query)).ToList();

        return userList;
    }

    private async Task<DefaultSearchResponseDto> GetDefaultSearchResponseDto(User user, IEnumerable<User> userList)
    {
        var userProfileList = await GetUserProfileList(userList);
        var teacherProfilesByCountry = GetProfilesByCountry(user.Country.Title, userProfileList, isTeacher: true);
        var expertProfilesByCountry = GetProfilesByCountry(user.Country.Title, userProfileList, isTeacher: false);
        var teacherProfilesByDisciplines =
            GetProfilesByDisciplines(user.UserDisciplines.Select(ud => ud.Discipline.Title), userProfileList,
                isTeacher: true);
        var expertProfilesByDisciplines =
            GetProfilesByDisciplines(user.UserDisciplines.Select(ud => ud.Discipline.Title), userProfileList,
                isTeacher: false);
        var classProfilesByCountry = GetClassProfiles(teacherProfilesByCountry).ToList();
        var classProfilesByDisciplines = GetClassProfiles(teacherProfilesByDisciplines).ToList();

        return new DefaultSearchResponseDto
        {
            TeacherProfilesByCountry = teacherProfilesByCountry,
            ExpertProfilesByCountry = expertProfilesByCountry,
            TeacherProfilesByDisciplines = teacherProfilesByDisciplines,
            ExpertProfilesByDisciplines = expertProfilesByDisciplines,
            ClassProfilesByCountry = classProfilesByCountry,
            ClassProfilesByDisciplines = classProfilesByDisciplines
        };
    }

    private async Task<IEnumerable<UserProfileDto>> GetUserProfileList(IEnumerable<User> userList)
    {
        var userProfileDtos = await Task.WhenAll(userList
            .Select(u =>
                _userHelper.MapUserToUserProfileDto(u)));
        return userProfileDtos;
    }

    private static IEnumerable<UserProfileDto> GetProfilesByCountry(string userCountry,
        IEnumerable<UserProfileDto> userProfileList, bool isTeacher)
    {
        return userProfileList
            .Where(up => up.CountryTitle == userCountry && up.IsATeacher == isTeacher);
    }

    private static IEnumerable<UserProfileDto> GetProfilesByDisciplines(IEnumerable<string> userDisciplines,
        IEnumerable<UserProfileDto> userProfileList, bool isTeacher)
    {
        return userProfileList
            .Where(up => up.DisciplineTitles
                .Intersect(userDisciplines)
                .Any() && up.IsATeacher == isTeacher);
    }

    private static IEnumerable<ClassProfileDto> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        return userProfileList
            .Select(c => c.ClasseDtos)
            .SelectMany(cl => cl)
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