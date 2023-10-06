using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.EditUserData;
using Wonderworld.Application.Dtos.UpdateDtos;

namespace Wonderworld.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class EditUserController : BaseController
{
    private readonly IEditUserAccountService _editUserAccountService;

    public EditUserController(IEditUserAccountService editUserAccountService)
    {
        _editUserAccountService = editUserAccountService;
    }

    [HttpPut("personal-info")]
    public async Task<IActionResult> EditUserPersonalInfo([FromBody] UpdatePersonalInfoRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _editUserAccountService.EditUserPersonalInfoAsync(userId, requestUserDto, Mediator);
        return result;
    }

    [HttpPut("institution")]
    public async Task<IActionResult> EditUserInstitution([FromBody] UpdateInstitutionRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _editUserAccountService.EditUserInstitutionAsync(userId, requestUserDto, Mediator);
        return result;
    }

    [HttpPut("professional-info")]
    public async Task<IActionResult> EditUserProfessionalInfo(
        [FromBody] UpdateProfessionalInfoRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);

        var result = await _editUserAccountService.EditUserProfessionalInfoAsync(userId, requestUserDto, Mediator);
        return result;
    }

    [HttpPut("email")]
    public async Task<IActionResult> EditUserEmail([FromBody] UpdateUserEmailRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _editUserAccountService.EditUserEmailAsync(userId, requestUserDto, Mediator);
        return result;
    }

    [HttpPut("password")]
    public async Task<IActionResult> EditUserPassword([FromBody] UpdateUserPasswordRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _editUserAccountService.EditUserPasswordAsync(userId, requestUserDto, Mediator);
        return result;
    }
}