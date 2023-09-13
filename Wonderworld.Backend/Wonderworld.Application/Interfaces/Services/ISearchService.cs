using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;

namespace Wonderworld.Application.Interfaces.Services;

public interface ISearchService
{
    public Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnSearchRequest(Guid userId, IMediator? mediator);
    public Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnSearchRequest(Guid userId, IMediator? mediator);
    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnSearchRequest(Guid userId, IMediator? mediator);
}