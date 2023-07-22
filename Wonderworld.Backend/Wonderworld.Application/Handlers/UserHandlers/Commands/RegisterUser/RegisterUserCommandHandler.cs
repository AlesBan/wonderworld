using AutoMapper;
using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;

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

    private User MapUser(RegisterUserCommand request)
    {
        var user = new User()
        {
            Email = request.Email,
            Password = request.Password,
            InterfaceLanguage = request.InterfaceLanguage
        };

        return user;
    }

    private async Task AddUser(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}