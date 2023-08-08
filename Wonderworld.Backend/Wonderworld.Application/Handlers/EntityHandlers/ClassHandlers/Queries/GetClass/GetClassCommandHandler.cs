using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;

public class GetClassCommandHandler: IRequestHandler<GetClassCommand, Class>
{
    private readonly ISharedLessonDbContext _context;

    public GetClassCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Class> Handle(GetClassCommand request, CancellationToken cancellationToken)
    {
        var @class = await _context.Classes.SingleOrDefaultAsync(c => 
            c.ClassId == request.ClassId, cancellationToken: cancellationToken);

        if (@class == null)
        {
            throw new NotFoundException(nameof(Class), request.ClassId);
        }

        return @class;
    }
}