using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.UpdateDtos;
using Wonderworld.Application.Dtos.UserDtos.UpdateDtos;

namespace Wonderworld.API.Services.EditUserData;

public interface IEditUserAccountService
{
    public Task<IActionResult> EditUserPersonalInfoAsync(Guid userId, UpdatePersonalInfoRequestDto requestUserDto, IMediator mediator);

    public Task<IActionResult> EditUserInstitutionAsync(Guid userId, UpdateInstitutionRequestDto requestUserDto, IMediator mediator);

    public Task<IActionResult> EditUserProfessionalInfoAsync(Guid userId, UpdateProfessionalInfoRequestDto requestUserDto, IMediator mediator);

    public Task<IActionResult> EditUserEmailAsync(Guid userId, UpdateUserEmailRequestDto requestUserDto, IMediator mediator);

    public Task<IActionResult> EditUserPasswordAsync(Guid userId, UpdateUserPasswordRequestDto requestUserDto, IMediator mediator);
}