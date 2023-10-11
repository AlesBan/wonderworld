using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Dtos.ClassDtos;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Infrastructure.Helpers;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public class DefaultSearchService : IDefaultSearchService
{
    private readonly IMapper _mapper;

    public DefaultSearchService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<DefaultSearchResponseDto> GetDefaultTeacherAndClassProfiles(Guid userId, IMediator mediator)
    {
        var user = await UserHelper.GetUserById(userId, mediator);

        var searchRequest = CreateDefaultSearchRequestDto(user);

        var userProfileList = (await UserHelper.GetUserProfilesByDefaultSearchRequest(searchRequest, mediator))
            .ToList();

        var defaultSearchResponseDto = CreateDefaultSearchResponseDto(user, userProfileList);
        return defaultSearchResponseDto;
    }

    private static DefaultSearchRequestDto CreateDefaultSearchRequestDto(User user)
    {
        var userDisciplines = GetUserDisciplines(user);

        var userCountry = GetUserCountry(user);

        return new DefaultSearchRequestDto
        {
            Disciplines = userDisciplines,
            Country = userCountry
        };
    }

    private DefaultSearchResponseDto CreateDefaultSearchResponseDto(User user,
        IReadOnlyCollection<UserProfileDto> userProfileList)
    {
        var userCountry = GetUserCountry(user);
        var userDisciplines = GetUserDisciplines(user).ToList();

        var teacherProfilesByCountry = GetTeacherProfilesByCountry(userCountry, userProfileList).ToList();
        var teacherProfilesByDisciplines = GetTeacherProfilesByDisciplines(userDisciplines, userProfileList).ToList();

        var expertProfilesByCountry = GetExpertProfilesByCountry(userCountry, userProfileList).ToList();
        var expertProfilesByDisciplines = GetExpertProfilesByDisciplines(userDisciplines, userProfileList).ToList();

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

    private static IEnumerable<UserProfileDto> GetExpertProfilesByDisciplines(List<Discipline> userDisciplines,
        IEnumerable<UserProfileDto> userProfileList)
    {
        var expertProfilesByDisciplines = userProfileList
            .Where(up => userDisciplines.Any(ud =>
                             up.Disciplines.Any(d =>
                                 d == ud.Title)) &&
                         up.IsAnExpert && !up.IsATeacher);

        return expertProfilesByDisciplines;
    }

    private static IEnumerable<UserProfileDto> GetExpertProfilesByCountry(Country userCountry,
        IEnumerable<UserProfileDto> userProfileList)
    {
        var expertProfilesByCountry = userProfileList
            .Where(up => up.CountryTitle == userCountry.Title &&
                         up.IsAnExpert && !up.IsATeacher);

        return expertProfilesByCountry;
    }

    private static IEnumerable<UserProfileDto> GetTeacherProfilesByDisciplines(
        IReadOnlyCollection<Discipline> userDisciplines, IEnumerable<UserProfileDto> userProfileList)
    {
        var teacherProfilesByDisciplines = userProfileList
            .Where(up => userDisciplines.Any(ud =>
                             up.Disciplines.Any(d =>
                                 d == ud.Title)) &&
                         up.IsATeacher);

        return teacherProfilesByDisciplines;
    }

    private static IEnumerable<UserProfileDto> GetTeacherProfilesByCountry(Country country,
        IEnumerable<UserProfileDto> userProfileList)
    {
        var teacherProfilesByCountry = userProfileList
            .Where(up =>
                up.CountryTitle == country.Title &&
                up.IsATeacher);

        return teacherProfilesByCountry;
    }

    private static Country GetUserCountry(User user)
    {
        var userCountry = user.Country;
        if (userCountry == null)
        {
            throw new NotFoundException(nameof(Country), user.UserId);
        }

        return userCountry;
    }

    private static IEnumerable<Discipline> GetUserDisciplines(User user)
    {
        var userDisciplines = user.UserDisciplines
            .Select(ud =>
                ud.Discipline)
            .ToList();
        if (userDisciplines == null)
        {
            throw new NotFoundException(nameof(Discipline), user.UserId);
        }

        return userDisciplines;
    }

    private IEnumerable<ClassProfileDto> GetClassProfiles(IEnumerable<UserProfileDto> userProfileList)
    {
        var classList = userProfileList.Select(up => up.Classes).ToList();

        var classProfileList = classList.Select(cp =>
                _mapper.Map<ClassProfileDto>(cp))
            .ToList();

        return classProfileList;
    }
}