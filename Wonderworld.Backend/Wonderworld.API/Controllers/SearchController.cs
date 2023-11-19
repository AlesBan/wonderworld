using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Infrastructure.Services.DataBaseDataService;
using Wonderworld.Infrastructure.Services.DefaultDataServices;
using Wonderworld.Infrastructure.Services.SearchService;

namespace Wonderworld.API.Controllers;

[Authorize]
[CheckUserCreateAccount]
[Produces("application/json")]
public class SearchController : BaseController
{
    private readonly IDefaultSearchService _defaultSearchDataService;
    private readonly ISearchService _searchService;
    private readonly IDataBaseDataService _searchDataService;

    public SearchController(IDefaultSearchService defaultSearchDataService, ISearchService searchService,
        IDataBaseDataService searchDataService)
    {
        _defaultSearchDataService = defaultSearchDataService;
        _searchService = searchService;
        _searchDataService = searchDataService;
    }

    [HttpGet("search-request")]
    public async Task<SearchResponseDto> GetTeachersAndClassesDependingOnSearchRequest(
        [FromQuery] SearchRequestDto searchRequest)
    {
        return await _searchService.GetTeacherAndClassProfiles(UserId, searchRequest, Mediator);
    }

    [HttpGet("default-search-request")]
    public async Task<DefaultSearchResponseDto> GetTeachersAndClassesDependingOnDefaultSearchRequest()
    {
        return await _defaultSearchDataService.GetDefaultTeacherAndClassProfiles(UserId, Mediator);
    }

    [HttpGet("all-country-locations")]
    public async Task<ExistingCountriesDto> GetAllCountryLocations()
    {
        var result = await _searchDataService.GetAllCounties(Mediator);

        return result;
    }
}