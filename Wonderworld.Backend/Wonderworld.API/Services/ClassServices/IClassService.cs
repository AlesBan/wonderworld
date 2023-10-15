using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.API.Services.ClassServices;

public interface IClassService
{
    public Task<IActionResult> CreateClass(Guid userId, CreateClassRequestDto requestClassDto, IMediator mediator);
    public Task<IActionResult> UpdateClass(Guid classId, UpdateClassRequestDto requestClassDto, IMediator mediator);
    public Task<IActionResult> DeleteClass(Guid classId, IMediator mediator);
}