using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClassProfileListDependingOnCountry;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnCountry;
using Wonderworld.Application.Interfaces.Services.Data;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;
using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public class DefaultSearchDataService : IDefaultSearchDataService
{
    private readonly IUserDataService _userDataService;
    private readonly IMediator _mediator;

    public DefaultSearchDataService(IUserDataService userDataService, IMediator mediator)
    {
        _userDataService = userDataService;
        _mediator = mediator;
    }

    public async Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnUserCountry(Guid userId, IMediator? mediator)
    {
        var user = GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetUserProfileListDependingOnCountryCommand(userCountry.CountryId, true, false);

        var teacherList = await _mediator.Send(query);
        return teacherList;
    }

    public async Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnUserCountry(Guid userId, IMediator? mediator)
    {
        var user = GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetUserProfileListDependingOnCountryCommand(userCountry.CountryId, false, true);

        var expertList = await _mediator.Send(query);
        return expertList;
    }

    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserCountry(Guid userId, IMediator? mediator)
    {
        var user = GetUserById(userId);

        var userCountry = GetUserCountry(user);

        var query = CreateGetClassProfileListDependingOnCountryCommand(userCountry.CountryId);

        var classList = _mediator.Send(query);
        return classList;
    }

    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserDisciplines(Guid userId, IMediator? mediator)
    {
        throw new NotImplementedException();
    }

    private User GetUserById(Guid userId)
    {
        var user = _userDataService.GetUserById(userId);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), userId);
        }

        return user;
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
}