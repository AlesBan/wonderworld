using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommandHandler : IRequestHandler<CreateInvitationCommand, Unit>
{
    private readonly ISharedLessonDbContext _context;

    public CreateInvitationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
    {
        var invitation = new Invitation
        {
            UserSenderId = request.UserSenderId,
            UserReceiverId = request.UserReceiverId,
            ClassSenderId = request.ClassSenderId,
            ClassReceiverId = request.ClassReceiverId,
            DateOfInvitation = request.DateOfInvitation,
            InvitationText = request.InvitationText,
            Status = request.Status
        };

        await _context.Invitations.AddAsync(invitation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}