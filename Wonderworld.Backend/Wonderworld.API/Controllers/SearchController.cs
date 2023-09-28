using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;

namespace Wonderworld.API.Controllers;

public class SearchController : BaseController
{
    private readonly IDefaultSearchService _defaultSearchDataService;
    private readonly ISearchService _searchService;

    public SearchController(IDefaultSearchService defaultSearchDataService, ISearchService searchService)
    {
        _defaultSearchDataService = defaultSearchDataService;
        _searchService = searchService;
    }

    [HttpGet("search-request")]
    public async Task<SearchResponseDto> GetTeachersAndClassesDependingOnSearchRequest(
        [FromBody] SearchRequestDto searchRequest)
    {
        return await _searchService.GetTeacherAndClassProfilesDependingOnSearchRequest(searchRequest, Mediator);
    }

    [HttpGet("default-search-request/{userId:guid}")]
    public async Task<DefaultSearchResponseDto> GetTeachersAndClassesDependingOnDefaultSearchRequest(Guid userId)
    {
        return await _defaultSearchDataService.GetDefaultTeacherAndClassProfiles(userId, Mediator);
    }
}