using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Application.Interfaces.Services;

public interface ISearchService
{
    /// <summary>
    /// GetTeacherAndClassProfilesDependingOnSearchRequest
    /// </summary>
    /// <param name="searchRequest"></param>
    /// <param name="mediator"></param>
    /// <returns></returns>
    public Task<SearchResponseDto> GetTeacherAndClassProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator mediator);
}