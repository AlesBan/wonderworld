using MediatR;
using Wonderworld.Application.Dtos.ProfileDtos;

namespace Wonderworld.Application.Interfaces.Services.DefaultDataServices;

public interface IDefaultSearchDataService
{
    public Task<IEnumerable<UserProfileDto>> GetTeachersDependingOnUserCountry(Guid userId, IMediator mediator);
    public Task<IEnumerable<UserProfileDto>> GetExpertsDependingOnUserCountry(Guid userId, IMediator mediator);
    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserCountry(Guid userId, IMediator mediator);
    public Task<IEnumerable<ClassProfileDto>> GetClassesDependingOnUserDisciplines(Guid userId, IMediator mediator);
}