using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListByDefaultSearchRequest;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Helpers;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public class DefaultSearchService : IDefaultSearchService
{
    private readonly IMapper _mapper;
    private readonly IUserHelper _userHelper;

    public DefaultSearchService(IMapper mapper, IUserHelper userHelper)
    {
        _mapper = mapper;
        _userHelper = userHelper;
    }

    public async Task<DefaultSearchResponseDto> GetDefaultTeacherAndClassProfiles(Guid userId, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId, mediator);

        var searchRequest = CreateDefaultSearchRequestDto(user);

        var userList = await GetUserListByDefaultSearchRequest(searchRequest, mediator);

        var defaultSearchResponseDto = await GetDefaultSearchResponseDto(user, userList);

        return defaultSearchResponseDto;
    }


    private async Task<IEnumerable<User>> GetUserListByDefaultSearchRequest(
        DefaultSearchRequestDto searchRequest,
        IMediator mediator)
    {
        var query = new GetUserListByDefaultSearchRequestCommand()
        {
            SearchRequest = searchRequest
        };

        var userList = (await mediator.Send(query)).ToList();

        return userList;
    }

    private static DefaultSearchRequestDto CreateDefaultSearchRequestDto(User user)
    {
        var userDisciplineIds = user.UserDisciplines
            .Select(ud =>
                ud.DisciplineId)
            .ToList();

        var userCountryId = user.CountryId;

        return new DefaultSearchRequestDto
        {
            DisciplineIds = userDisciplineIds,
            CountryId = userCountryId
        };
    }

    private async Task<DefaultSearchResponseDto> GetDefaultSearchResponseDto(User user,
        IEnumerable<User> userList)
    {
        if (user.Country == null)
        {
            throw new UserPropertyNotFoundException(user.UserId, "Country");
        }

        var userCountryTitle = user.Country.Title;

        var userDisciplineTitles = user.UserDisciplines
            .Select(ud =>
                ud.Discipline.Title)
            .ToList();

        var teacherProfilesByCountry = await
            GetTeacherProfilesByCountry(userCountryTitle, userList);
        var teacherProfilesByDisciplines = await
            GetTeacherProfilesByDisciplines(userDisciplineTitles, userList);

        var expertProfilesByCountry = await
            GetExpertProfilesByCountry(userCountryTitle, userList);
        var expertProfilesByDisciplines = await
            GetExpertProfilesByDisciplines(userDisciplineTitles, userList);

        var classProfilesByCountry = GetClassProfiles(teacherProfilesByCountry).ToList();
        var classProfilesByDisciplines = GetClassProfiles(teacherProfilesByDisciplines).ToList();

        var responseDto = new DefaultSearchResponseDto
        {
            TeacherProfilesByCountry = teacherProfilesByCountry,
            ExpertProfilesByCountry = expertProfilesByCountry,
            TeacherProfilesByDisciplines = teacherProfilesByDisciplines,
            ExpertProfilesByDisciplines = expertProfilesByDisciplines,
            ClassProfilesByCountry = classProfilesByCountry,
            ClassProfilesByDisciplines = classProfilesByDisciplines
        };

        return responseDto;
    }

    private async Task<IEnumerable<UserProfileDto>> GetUserProfileList(IEnumerable<User> userList)
    {
        var userProfileDtosTasks = userList.Select(async u =>
            await _userHelper.MapUserToUserProfileDto(u));
        var userProfileDtos = await Task.WhenAll(userProfileDtosTasks);

        return userProfileDtos;
    }

    private async Task<IEnumerable<UserProfileDto>> GetExpertProfilesByDisciplines(
        IEnumerable<string> userDisciplines,
        IEnumerable<User> userList)
    {
        var expertByDisciplines = userList
            .Where(up => userDisciplines.Any(ud =>
                             up.UserDisciplines.Select(udd => udd.Discipline.Title)
                                 .Any(d =>
                                     d == ud)) &&
                         up.IsAnExpert && !up.IsATeacher);
        var expertProfiles = await GetUserProfileList(expertByDisciplines);

        return expertProfiles;
    }

    private async Task<IEnumerable<UserProfileDto>> GetExpertProfilesByCountry(string userCountry,
        IEnumerable<User> userProfileList)
    {
        var expertByCountry = userProfileList
            .Where(up => up.Country.Title == userCountry &&
                         up.IsAnExpert && !up.IsATeacher);

        var expertProfiles = await GetUserProfileList(expertByCountry);


        return expertProfiles;
    }

    private async Task<IEnumerable<UserProfileDto>> GetTeacherProfilesByDisciplines(
        IEnumerable<string> userDisciplines, IEnumerable<User> userList)
    {
        var teachersByDisciplines = userList
            .Where(up => userDisciplines.Any(ud =>
                up.UserDisciplines.Select(udd => udd.Discipline.Title)
                    .Any(d =>
                        d == ud)) && up.IsATeacher);

        var teacherProfiles = await GetUserProfileList(teachersByDisciplines);

        return teacherProfiles;
    }

    private async Task<IEnumerable<UserProfileDto>> GetTeacherProfilesByCountry(string userCountry,
        IEnumerable<User> userProfileList)
    {
        var teacherByCountry = userProfileList
            .Where(up =>
                up.Country.Title == userCountry &&
                up.IsATeacher);

        var teacherProfilesByCountry = await GetUserProfileList(teacherByCountry);
        return teacherProfilesByCountry;
    }

    private IEnumerable<ClassProfileDto> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        var classList = userProfileList.SelectMany(up => up.ClasseDtos);

        var classProfiles = classList.ToList().Select(c =>
            new ClassProfileDto
            {
                ClassId = c.ClassId,
                Title = c.Title,
                UserFullName = c.UserFullName,
                UserRating = c.UserRating,
                Grade = c.Grade,
                Languages = c.Languages,
                Disciplines = c.Disciplines,
                PhotoUrl = c.PhotoUrl!
            }).ToList();

        return classProfiles;
    }
}