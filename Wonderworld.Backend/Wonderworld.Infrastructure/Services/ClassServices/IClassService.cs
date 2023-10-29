using MediatR;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.Infrastructure.Services.ClassServices;

public interface IClassService
{
    public Task<ClassProfileDto> CreateClass(Guid userId, CreateClassRequestDto requestClassDto, IMediator mediator);
    public Task<ClassProfileDto> GetClassProfile(Guid classId, IMediator mediator);
    public Task<ClassProfileDto> UpdateClass(Guid classId, UpdateClassRequestDto requestClassDto, IMediator mediator);
    public Task DeleteClass(Guid classId, IMediator mediator);
}