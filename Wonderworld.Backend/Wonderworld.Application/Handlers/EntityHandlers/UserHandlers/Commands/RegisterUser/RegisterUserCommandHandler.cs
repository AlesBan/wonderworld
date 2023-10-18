using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public RegisterUserCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _context.Users
            .AnyAsync(x => x.Email == request.User.Email, cancellationToken);
        
        if (userExists)
        {
            throw new UserAlreadyExistsException(request.User.Email);
        }
        
        var user = request.User;
        
        await AddUser(user, cancellationToken);

        return await Task.FromResult(user);
    }

    private async Task AddUser(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}