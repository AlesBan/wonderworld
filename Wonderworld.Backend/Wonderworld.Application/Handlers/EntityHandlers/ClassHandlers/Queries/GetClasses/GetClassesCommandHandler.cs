using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClasses;

public class GetClassesCommandHandler : IRequestHandler<GetClassesCommand, IEnumerable<Class>>
{
    private readonly ISharedLessonDbContext _context;

    public GetClassesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Class>> Handle(GetClassesCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Classes)
            .FirstOrDefaultAsync(u =>
                u.UserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        return user.Classes;
    }
}