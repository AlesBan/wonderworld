using MediatR;
using Wonderworld.Application.Common.Exceptions.Class;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;
using static System.Threading.Tasks.Task;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.CreateInvitation;

public class CreateInvitationCommandHandler : IRequestHandler<CreateInvitationCommand, Invitation>
{
    private readonly ISharedLessonDbContext _context;

    public CreateInvitationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Invitation> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
    {
        var invitation = new Invitation
        {
            UserSenderId = request.UserSenderId,
            UserReceiverId = request.UserReceiverId,
            ClassSenderId = request.ClassSenderId,
            ClassReceiverId = request.ClassReceiverId,
            DateOfInvitation = request.DateOfInvitation.ToUniversalTime(),
            InvitationText = request.InvitationText,
            Status = request.Status
        };

        ValidateClassReceiverId(request.UserSenderId, request.ClassReceiverId);
        
        await _context.Invitations.AddAsync(invitation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return invitation;
    }

    private void ValidateClassReceiverId(Guid userId, Guid classReceiverId)
    {
        var classReceiverIsUserClass = _context.Classes
            .Any(c => c.UserId == userId);

        if (!classReceiverIsUserClass)
        {
            throw new InvalidClassReceiverException();
        }
    }
}