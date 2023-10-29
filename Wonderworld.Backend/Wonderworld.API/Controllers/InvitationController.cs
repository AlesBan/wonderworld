using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.API.Helpers;
using Wonderworld.Application.Dtos.InvitationDtos;
using Wonderworld.Infrastructure.Services.InvitationServices;

namespace Wonderworld.API.Controllers;

[Authorize]
[CheckUserCreateAccount]
public class InvitationController : BaseController
{
    private readonly IInvitationService _invitationService;

    public InvitationController(IInvitationService invitationService)
    {
        _invitationService = invitationService;
    }

    [HttpPost("create-invitation")]
    public async Task<IActionResult> CreateInvitation([FromBody] CreateInvitationRequestDto createInvitationRequestDto)
    {
        await _invitationService.CreateInvitation(UserId, Mediator, createInvitationRequestDto);
        return ResponseHelper.GetOkResult();
    }
}