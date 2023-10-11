using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.API.Services.ClassServices;

public class ClassService : IClassService
{
    public Task<IActionResult> CreateClass(Guid userId, CreateClassRequestDto requestClassDto, IMediator mediator)
    {
        return Task.FromResult<IActionResult>(null);
    }

    public Task<IActionResult> UpdateClass(Guid classId, UpdateClassRequestDto requestClassDto, IMediator mediator)
    {
        return Task.FromResult<IActionResult>(null);
    }

    public Task<IActionResult> DeleteClass(Guid classId, IMediator mediator)
    {
        return Task.FromResult<IActionResult>(null);
    }
}