using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Infrastructure.Services.DefaultDataServices;

public interface IDefaultSearchService
{
    public Task<DefaultSearchResponseDto> GetDefaultTeacherAndClassProfiles(Guid userId, IMediator mediator);
}