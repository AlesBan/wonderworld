using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.InvitationDtos;

namespace Wonderworld.API.Services.InvitationServices;

public interface IInvitationService
{
    Task<IActionResult> CreateInvitation(Guid userSenderId, IMediator mediator,
        [FromBody] CreateInvitationRequestDto requestInvitationDto);
}