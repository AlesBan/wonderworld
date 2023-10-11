using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.ClassServices;
using Wonderworld.Application.Dtos.ClassDtos;

namespace Wonderworld.API.Controllers;

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
        try
        {
            var result = await _classService.CreateClass(UserId, requestClassDto, Mediator);

            return result;
        }
        catch (Exception e)
        {
            return ResponseHelper.GetBadRequest(e.Message);
        }
    }

    [HttpPut("update-class/{classId:guid}")]
    public async Task<IActionResult> UpdateClass([FromBody] UpdateClassRequestDto requestClassDto, Guid classId)
    {
        try
        {
            var result = await _classService.UpdateClass(classId, requestClassDto, Mediator);
            return result;
        }
        catch (Exception e)
        {
            return ResponseHelper.GetBadRequest(e.Message);
        }
    }

    [HttpDelete("delete-class/{classId:guid}")]
    public async Task<IActionResult> DeleteClass(Guid classId)
    {
        try
        {
            var result = await _classService.DeleteClass(classId, Mediator);
            return result;
        }
        catch (Exception e)
        {
            return ResponseHelper.GetBadRequest(e.Message);
        }
    }
}