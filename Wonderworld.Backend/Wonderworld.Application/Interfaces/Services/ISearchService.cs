using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Application.Interfaces.Services;

public interface ISearchService
{
    public Task<IEnumerable<UserProfileDto>> GetTeacherProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator mediator);
    public Task<IEnumerable<UserProfileDto>> GetExpertProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator mediator);
    public Task<IEnumerable<ClassProfileDto>> GetClassProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator mediator);
}