using MediatR;
using Microsoft.Extensions.Configuration;
using Wonderworld.API.Constants;
using Wonderworld.Application.Dtos.InvitationDtos;
using Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;
using Wonderworld.Domain.Enums;
using Wonderworld.Infrastructure.Helpers;
using Wonderworld.Infrastructure.Services.EmailHandlerService;

namespace Wonderworld.Infrastructure.Services.InvitationServices;

public class InvitationService : IInvitationService
{
    private readonly IEmailHandlerService _emailHandlerService;
    private readonly IConfiguration _configuration;

    public InvitationService(IEmailHandlerService emailHandlerService, IConfiguration configuration)
    {
        _emailHandlerService = emailHandlerService;
        _configuration = configuration;
    }

    public async Task CreateInvitation(Guid userSenderId, IMediator mediator,
        CreateInvitationRequestDto requestInvitationDto)
    {
        var userReceiverId = await UserHelper.GetUserIdByClassId(requestInvitationDto.ClassReceiverId, mediator);
        var dateOfInvitation = DateTime.Parse(requestInvitationDto.DateOfInvitation);
        var command = new CreateInvitationCommand
        {
            UserSenderId = userSenderId,
            UserReceiverId = userReceiverId,
            ClassSenderId = requestInvitationDto.ClassSenderId,
            ClassReceiverId = requestInvitationDto.ClassReceiverId,
            DateOfInvitation = dateOfInvitation,
            Status = InvitationStatus.Pending.ToString(),
            InvitationText = requestInvitationDto.InvitationText
        };
        await mediator.Send(command);
        
        await SendInvitationEmail(userSenderId, userReceiverId, dateOfInvitation, mediator);
    }

    private async Task SendInvitationEmail(Guid userSenderId, Guid userReceiverId, DateTime dateOfInvitation, IMediator mediator)
    {
        var userSender = await UserHelper.GetUserById(userSenderId, mediator);
        var userReceiver = await UserHelper.GetUserById(userReceiverId, mediator);

        await _emailHandlerService.SendAsync(_configuration, userSender.Email, EmailConstants.EmailInvitationSubject,
            EmailConstants.GetEmailSenderInvitationMessage(userReceiver.Email, dateOfInvitation));   
        await _emailHandlerService.SendAsync(_configuration, userReceiver.Email, EmailConstants.EmailInvitationSubject,
            EmailConstants.GetEmailReceiverInvitationMessage(userSender.Email, dateOfInvitation));
    }
}