using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Helpers.TokenHelper;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserVerification;

public class UpdateUserVerificationCommandHandler : IRequestHandler<UpdateUserVerificationCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly ITokenHelper _tokenHelper;

    public UpdateUserVerificationCommandHandler(ISharedLessonDbContext sharedLessonDbContext, ITokenHelper tokenHelper)
    {
        _context = sharedLessonDbContext;
        _tokenHelper = tokenHelper;
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
        
        if (user.VerificationCode != request.VerificationCode)
        {
            throw new InvalidVerificationCodeProvidedException();
        }

        user.IsVerified = true;
        user.VerifiedAt = DateTime.UtcNow;
        user.AccessToken = _tokenHelper.CreateToken(user);

        _context.Users.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}