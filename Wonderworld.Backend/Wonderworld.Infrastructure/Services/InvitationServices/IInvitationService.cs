using MediatR;
using Wonderworld.Application.Dtos.InvitationDtos;

namespace Wonderworld.Infrastructure.Services.InvitationServices;

public interface IInvitationService
{
    Task CreateInvitation(Guid userSenderId, IMediator mediator, CreateInvitationRequestDto requestInvitationDto);
}