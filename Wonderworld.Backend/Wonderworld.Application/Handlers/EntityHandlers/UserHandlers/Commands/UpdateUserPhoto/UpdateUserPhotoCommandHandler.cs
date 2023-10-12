using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPhoto;

public class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserPhotoCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
    {
        request.User.PhotoUrl = request.NewPhotoUrl;

        _context.Users.Attach(request.User).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}