using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Dtos.SearchDtos;
using Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListDependingOnSearchQuery;
using Wonderworld.Application.Interfaces.Services;

namespace Wonderworld.Infrastructure.Services;

public class SearchService : ISearchService
{
    public async Task<IEnumerable<UserProfileDto>> GetTeacherProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator mediator)
    {
        var query = GetUserCreateGetTeacherProfilesDependingOnSearchRequestCommand(searchRequest);
        
        var teacherList = await mediator.Send(query);
        
        return teacherList;
    }

    public Task<IEnumerable<UserProfileDto>> GetExpertProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator? mediator)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClassProfileDto>> GetClassProfilesDependingOnSearchRequest(SearchRequestDto searchRequest, IMediator? mediator)
    {
        throw new NotImplementedException();
    }
    
    private GetUserProfileListDependingOnSearchQueryCommand GetUserCreateGetTeacherProfilesDependingOnSearchRequestCommand(SearchRequestDto searchRequest)
    {
        return new GetUserProfileListDependingOnSearchQueryCommand()
        {
            SearchRequest = searchRequest
        };
    }
}