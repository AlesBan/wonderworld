using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Services.EditUserData;
using Wonderworld.Application.Dtos.UpdateDtos;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]/{userId:guid}")]
public class EditUserController : BaseController
{
    private readonly IEditUserAccountService _editUserAccountService;
    public EditUserController(IEditUserAccountService editUserAccountService)
    {
        _editUserAccountService = editUserAccountService;
    }

    [HttpPut("personal-info")]
    public async Task<IActionResult> EditUserPersonalInfo(Guid userId, [FromBody] UpdatePersonalInfoRequestDto requestUserDto)
    {
        var result = await _editUserAccountService.EditUserPersonalInfo(userId, requestUserDto, Mediator);
        return result;
    }

    [HttpPut("institution")]
    public async Task<IActionResult> EditUserInstitution(Guid userId,
        [FromBody] UpdateInstitutionRequestDto requestUserDto)
    {
        var result = await _editUserAccountService.EditUserInstitution(userId, requestUserDto, Mediator);
        return result;
    }
    
    [HttpPut("professional-info")]
    public async Task<IActionResult> EditUserProfessionalInfo(Guid userId,
        [FromBody] UpdateProfessionalInfoRequestDto requestUserDto)
    {
        var result = await _editUserAccountService.EditUserProfessionalInfo(userId, requestUserDto, Mediator);
        return result;
    }
    
    [HttpPut("email")]
    public async Task<IActionResult> EditUserEmail(Guid userId,
        [FromBody] UpdateUserEmailRequestDto requestUserDto)
    {
        var result = await _editUserAccountService.EditUserEmail(userId, requestUserDto, Mediator);
        return result;
    }
    
    [HttpPut("password")]
    public async Task<IActionResult> EditUserPassword(Guid userId,
        [FromBody] UpdateUserPasswordRequestDto requestUserDto)
    {
        var result = await _editUserAccountService.EditUserPassword(userId, requestUserDto, Mediator);
        return result;
    }
}