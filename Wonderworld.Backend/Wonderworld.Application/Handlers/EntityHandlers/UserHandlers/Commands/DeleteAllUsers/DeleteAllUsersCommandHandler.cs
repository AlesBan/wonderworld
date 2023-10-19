using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.DeleteAllUsers;

public class DeleteAllUsersCommandHandler : IRequestHandler<DeleteAllUsersCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteAllUsersCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
    {
        var rows = from o in _context.Users
            select o;
        foreach (var row in rows)
        {
            _context.Users.Remove(row);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}