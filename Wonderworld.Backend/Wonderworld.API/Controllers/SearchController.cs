using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;

namespace Wonderworld.API.Controllers;

public class SearchController : BaseController
{
    private readonly IDefaultSearchDataService _defaultSearchDataService;

    public SearchController(IDefaultSearchDataService defaultSearchDataService)
    {
        _defaultSearchDataService = defaultSearchDataService;
    }

    [HttpGet("teacher-profiles-depending-on-user-country/{userId:guid}")]
    public async Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnUserCountry(Guid userId)
    {
        return await _defaultSearchDataService.GetTeachersDependingOnUserCountry(userId, Mediator);
    }

    [HttpGet("expert-profiles-depending-on-user-country/{userId:guid}")]
    public async Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnUserCountry(Guid userId)
    {
        return await _defaultSearchDataService.GetExpertsDependingOnUserCountry(userId, Mediator);
    }

    [HttpGet("class-profiles-depending-on-user-country/{userId:guid}")]
    public async Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserCountry(Guid userId)
    {
        return await _defaultSearchDataService.GetClassesDependingOnUserCountry(userId, Mediator);
    }

    [HttpGet("class-profiles-depending-on-user-disciplines/{userId:guid}")]
    public async Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserDiscipline(Guid userId)
    {
        return await _defaultSearchDataService.GetClassesDependingOnUserDisciplines(userId, Mediator);
    }
}