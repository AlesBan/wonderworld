using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnCountry;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnCountry;
using Wonderworld.Application.Interfaces.Helpers;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public class DefaultSearchDataService : IDefaultSearchDataService
{
    private readonly IUserHelper _userHelper;

    public DefaultSearchDataService(IUserHelper userHelper)
    {
        _userHelper = userHelper;
    }

    public async Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnUserCountry(Guid userId, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetUserProfileListDependingOnCountryCommand(userCountry.CountryId, true, false);

        var teacherList = await mediator.Send(query);
        return teacherList;
    }

    public async Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnUserCountry(Guid userId, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetUserProfileListDependingOnCountryCommand(userCountry.CountryId, false, true);

        var expertList = await mediator.Send(query);
        return expertList;
    }

    public async Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserCountry(Guid userId, IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetClassProfileListDependingOnCountryCommand(userCountry.CountryId);

        var classList = await mediator.Send(query);
        return classList;
    }

    public async Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserDisciplines(Guid userId,
        IMediator mediator)
    {
        var user = await _userHelper.GetUserById(userId);

        var userDisciplines = GetUserDisciplines(user);

        var query = CreateGetClassProfileListDependingOnDisciplinesCommand(userDisciplines);

        var classList = await mediator.Send(query);

        return classList;
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

    private static List<Discipline> GetUserDisciplines(User user)
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

    private static GetUserProfileListDependingOnCountryCommand CreateGetUserProfileListDependingOnCountryCommand(
        Guid countryId, bool isATeacher, bool isAnExpert)
    {
        return new GetUserProfileListDependingOnCountryCommand()
        {
            CountryId = countryId,
            IsATeacher = isATeacher,
            IsAnExpert = isAnExpert
        };
    }

    private static GetClassProfileListDependingOnCountryCommand CreateGetClassProfileListDependingOnCountryCommand(
        Guid countryId)
    {
        return new GetClassProfileListDependingOnCountryCommand()
        {
            CountryId = countryId
        };
    }

    private static GetClassProfileListDependingOnDisciplinesCommand
        CreateGetClassProfileListDependingOnDisciplinesCommand(List<Discipline> disciplines)
    {
        return new GetClassProfileListDependingOnDisciplinesCommand()
        {
            Disciplines = disciplines
        };
    }
}