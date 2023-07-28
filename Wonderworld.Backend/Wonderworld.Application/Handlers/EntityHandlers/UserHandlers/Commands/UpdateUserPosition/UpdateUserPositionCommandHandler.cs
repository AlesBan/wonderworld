using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPosition;

public class UpdateUserPositionCommandHandler: IRequestHandler<UpdateUserPositionCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserPositionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserPositionCommand request, CancellationToken cancellationToken)
    {
        
        MapUser(request.User, request);

        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(Unit.Value);
    }

    private static void MapUser(User user, UpdateUserPositionCommand request)
    {
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
    }
}