using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;

public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserEmailCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => 
                u.UserId == request.UserId, cancellationToken: cancellationToken);
        
        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
        
        user.Email = request.Email;
        _context.Users.Attach(user).State = EntityState.Modified;
        
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}