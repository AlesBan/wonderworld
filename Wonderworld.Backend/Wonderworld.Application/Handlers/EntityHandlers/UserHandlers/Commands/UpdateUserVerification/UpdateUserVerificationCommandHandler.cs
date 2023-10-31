using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserVerification;

public class UpdateUserVerificationCommandHandler : IRequestHandler<UpdateUserVerificationCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserVerificationCommandHandler(ISharedLessonDbContext sharedLessonDbContext)
    {
        _context = sharedLessonDbContext;
    }

    public async Task<User> Handle(UpdateUserVerificationCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.UserId == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        user.IsVerified = true;
        user.VerifiedAt = DateTime.UtcNow;

        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}