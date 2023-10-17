using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.ClassServices;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.API.Controllers;

[Authorize]
public class ClassController : BaseController
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpPost("create-class")]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassRequestDto requestClassDto)
    {
        var result = await _classService.CreateClass(UserId, requestClassDto, Mediator);
        return result;
    }

    [HttpPut("update-class/{classId:guid}")]
    public async Task<IActionResult> UpdateClass([FromBody] UpdateClassRequestDto requestClassDto, Guid classId)
    {
        var result = await _classService.UpdateClass(classId, requestClassDto, Mediator);
        return result;
    }

    [HttpDelete("delete-class/{classId:guid}")]
    public async Task<IActionResult> DeleteClass(Guid classId)
    {
        var result = await _classService.DeleteClass(classId, Mediator);
        return result;
    }
}