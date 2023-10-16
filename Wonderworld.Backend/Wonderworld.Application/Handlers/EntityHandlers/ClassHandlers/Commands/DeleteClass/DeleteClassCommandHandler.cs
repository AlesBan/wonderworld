using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

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
        var @class = await _context.Classes
            .SingleOrDefaultAsync(x => x.ClassId == request.ClassId, cancellationToken: cancellationToken);
        
        if (@class == null)
        {
            throw new NotFoundException(nameof(Class), request.ClassId);
        }
        
        _context.Classes.Remove(@class);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}