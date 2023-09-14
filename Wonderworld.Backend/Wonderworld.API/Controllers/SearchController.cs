using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;

namespace Wonderworld.API.Controllers;

public class SearchController : BaseController
{
    private readonly IDefaultSearchDataService _defaultSearchDataService;
    private readonly ISearchService _searchService;

    public SearchController(IDefaultSearchDataService defaultSearchDataService, ISearchService searchService)
    {
        _defaultSearchDataService = defaultSearchDataService;
        _searchService = searchService;
    }
    
    [HttpGet("teacher-profiles-depending-on-search-request")]
    public async Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnSearchRequest([FromBody] SearchRequestDto searchRequest)
    {
        return await _searchService.GetTeacherProfilesDependingOnSearchRequest(searchRequest, Mediator);
    }
    
    [HttpGet("expert-profiles-depending-on-search-request")]
    public async Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnSearchRequest([FromBody] SearchRequestDto searchRequest)
    {
        return await _searchService.GetExpertProfilesDependingOnSearchRequest(searchRequest, Mediator);
    }
    
    [HttpGet("class-profiles-depending-on-search-request")]
    public async Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnSearchRequest([FromBody] SearchRequestDto searchRequest)
    {
        return await _searchService.GetClassProfilesDependingOnSearchRequest(searchRequest, Mediator);
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