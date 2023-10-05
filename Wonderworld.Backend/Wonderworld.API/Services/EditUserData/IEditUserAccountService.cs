using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.UpdateDtos;

namespace Wonderworld.API.Services.EditUserData;

public interface IEditUserAccountService
{
    public Task<IActionResult> EditUserPersonalInfo(Guid userId, UpdatePersonalInfoRequestDto requestUserDto,
        IMediator mediator);

    public Task<IActionResult> EditUserInstitution(Guid userId, UpdateInstitutionRequestDto requestUserDto,
        IMediator mediator);

    public Task<IActionResult> EditUserProfessionalInfo(Guid userId, UpdateProfessionalInfoRequestDto requestUserDto,
        IMediator mediator);

    public Task<IActionResult> EditUserEmail(Guid userId, UpdateUserEmailRequestDto requestUserDto, IMediator mediator);

    public Task<IActionResult> EditUserPassword(Guid userId, UpdateUserPasswordRequestDto requestUserDto,
        IMediator mediator);
}