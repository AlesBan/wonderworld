using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserDescription;

public class UpdateUserDescriptionCommandHandler : IRequestHandler<UpdateUserDescriptionCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserDescriptionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserDescriptionCommand request, CancellationToken cancellationToken)
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
    
    private static void MapUser(User user, UpdateUserDescriptionCommand request)
    {
        user.Description = request.Description;
    }
}