using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Application.Interfaces.Services;

namespace Wonderworld.Infrastructure.Services;

public class SearchService : ISearchService
{
    public Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnSearchRequest(Guid userId, IMediator? mediator)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnSearchRequest(Guid userId, IMediator? mediator)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnSearchRequest(Guid userId, IMediator? mediator)
    {
        throw new NotImplementedException();
    }
}