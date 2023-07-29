using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.InvitationHandlers.Commands.DeleteInvitation;

public class DeleteInvitationCommandHandler : IRequestHandler<DeleteInvitationCommand>
{
    private readonly ISharedLessonDbContext _context;
    public DeleteInvitationCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteInvitationCommand request, CancellationToken cancellationToken)
    {
        _context.Invitations.Remove(request.Invitation);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}