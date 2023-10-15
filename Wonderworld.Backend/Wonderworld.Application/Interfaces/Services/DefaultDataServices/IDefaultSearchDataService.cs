using MediatR;
using Wonderworld.Application.Dtos.SearchDtos;

namespace Wonderworld.Application.Interfaces.Services.DefaultDataServices;

public interface IDefaultSearchService
{
    public Task<DefaultSearchResponseDto> GetDefaultTeacherAndClassProfiles(Guid userId, IMediator mediator);
}