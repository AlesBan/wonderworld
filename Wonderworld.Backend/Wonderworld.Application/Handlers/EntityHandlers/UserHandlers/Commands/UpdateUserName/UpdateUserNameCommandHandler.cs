using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserName;

public class UpdateUserNameCommandHandler : IRequestHandler<UpdateUserNameCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserNameCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
    {
        MapUser(request.User, request);

        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    private static void MapUser(User user, UpdateUserNameCommand request)
    {
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
    }
}