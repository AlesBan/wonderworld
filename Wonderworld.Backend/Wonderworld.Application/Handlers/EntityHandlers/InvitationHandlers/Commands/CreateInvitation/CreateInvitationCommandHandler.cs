using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommandHandler : IRequestHandler<CreateInvitationCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateInvitationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
    {
        var invitation = new Invitation()
        {
            UserSender = request.UserSender,
            UserRecipient = request.UserRecipient,
            ClassSender = request.ClassSender,
            ClassRecipient = request.ClassRecipient,
            DateOfInvitation = request.DateOfInvitation,
            InvitationText = request.InvitationText,
            Status = request.Status
        };

        await _context.Invitations.AddAsync(invitation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return invitation.InvitationId;
    }
}