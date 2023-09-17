using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public RegisterUserCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = MapUser(request);

        await AddUser(user, cancellationToken);

        return await Task.FromResult(user.UserId);
    }

    private static User MapUser(RegisterUserCommand request)
    {
        var user = new User()
        {
            Email = request.Email,
            Password = request.Password,
        };

        return user;
    }

    private async Task AddUser(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}