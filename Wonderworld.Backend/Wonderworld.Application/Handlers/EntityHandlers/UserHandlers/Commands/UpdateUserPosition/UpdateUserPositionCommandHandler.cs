using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserPosition;

public class UpdateUserPositionCommandHandler: IRequestHandler<UpdateUserPositionCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserPositionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserPositionCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(t =>
                    t.UserId == request.UserId,
                cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        
        MapUser(user, request);

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(Unit.Value);
    }

    private static void MapUser(User user, UpdateUserPositionCommand request)
    {
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
    }
}