using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;

public class GetClassCommandHandler : IRequestHandler<GetClassCommand, Class>
{
    private readonly ISharedLessonDbContext _context;

    public GetClassCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Class> Handle(GetClassCommand request, CancellationToken cancellationToken)
    {
        var @class = await _context.Classes
            .Include(c => c.User)
            .ThenInclude(u => u.ReceivedReviews)
            .Include(c => c.Grade)
            .Include(c => c.ClassDisciplines)
            .ThenInclude(cd => cd.Discipline)
            .Include(c => c.ClassLanguages)
            .ThenInclude(cl => cl.Language)
            .SingleOrDefaultAsync(c =>
                c.ClassId == request.ClassId, cancellationToken: cancellationToken);

        if (@class == null)
        {
            throw new NotFoundException(nameof(Class), request.ClassId);
        }

        return @class;
    }
}