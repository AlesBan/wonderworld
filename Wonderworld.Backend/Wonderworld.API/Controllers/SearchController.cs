using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Application.Interfaces.Services.DefaultDataServices;

namespace Wonderworld.API.Controllers;

[Authorize]
[CheckUserCreateAccount]
[Produces("application/json")]
public class SearchController : BaseController
{
    private readonly IDefaultSearchService _defaultSearchDataService;
    private readonly ISearchService _searchService;

    public SearchController(IDefaultSearchService defaultSearchDataService, ISearchService searchService)
    {
        _defaultSearchDataService = defaultSearchDataService;
        _searchService = searchService;
    }

    /// <summary>
    /// Get Teachers and Classes depending on search request
    /// </summary>
    /// <remarks>
    /// GET /api/search-request
    /// </remarks>
    /// <param name="searchRequest"></param>
    /// <returns>
    /// Returns SearchResponse
    /// </returns>
    /// <response code="200">Returns SearchResponse</response>
    /// <response code="400">Returns ResponseResult</response>
    [HttpGet("search-request")]
    public async Task<SearchResponseDto> GetTeachersAndClassesDependingOnSearchRequest(
        [FromBody] SearchRequestDto searchRequest)
    {
        return await _searchService.GetTeacherAndClassProfilesDependingOnSearchRequest(searchRequest, Mediator);
    }

    /// <summary>
    /// Get Teachers and Classes depending on default search request
    /// </summary>
    /// <remarks>
    /// GET /api/default-search-request
    /// </remarks>
    /// <returns>
    /// Returns DefaultSearchResponse
    /// </returns>
    /// <response code="200">Returns DefaultSearchResponse</response>
    /// <response code="400">Returns ResponseResult</response>
    [HttpGet("default-search-request")]
    public async Task<DefaultSearchResponseDto> GetTeachersAndClassesDependingOnDefaultSearchRequest()
    {
        return await _defaultSearchDataService.GetDefaultTeacherAndClassProfiles(UserId, Mediator);
    }
}