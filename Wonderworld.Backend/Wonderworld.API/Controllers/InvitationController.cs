using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Services.InvitationServices;
using Wonderworld.Application.Dtos.InvitationDtos;

namespace Wonderworld.API.Controllers;

public class InvitationController : BaseController
{
    private readonly IInvitationService _invitationService;

    public InvitationController(IInvitationService invitationService)
    {
        _invitationService = invitationService;
    }

    [HttpGet("create-invitation")]
    public IActionResult CreateInvitation([FromBody] CreateInvitationRequestDto createInvitationRequestDto)
    {
        return Ok(_invitationService.CreateInvitation(UserId, Mediator, createInvitationRequestDto));
    }
}