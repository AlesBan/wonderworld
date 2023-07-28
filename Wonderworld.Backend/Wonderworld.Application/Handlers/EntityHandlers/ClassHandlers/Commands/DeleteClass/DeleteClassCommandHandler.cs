using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.DeleteClass;

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteClassCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        _context.Classes.Remove(request.Class);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}