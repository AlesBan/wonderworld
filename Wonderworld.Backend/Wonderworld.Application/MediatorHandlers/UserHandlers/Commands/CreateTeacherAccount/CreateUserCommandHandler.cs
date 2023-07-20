using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.CreateTeacherAccount;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IServiceDbContext? _context;

    public CreateUserCommandHandler(IServiceDbContext? serviceDbContext)
    {
        _context = serviceDbContext;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await MapUser(request);
        await AddUser(user, cancellationToken);

        return await Task.FromResult(user.UserId);
    }

    private static Task<User> MapUser(CreateUserCommand request)
    {
        return Task.FromResult(new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,

            IsATeacher = request.IsATeacher,
            IsAnExpert = request.IsAnExpert,

            InterfaceLanguage = request.InterfaceLanguage,

            CityLocation = request.CityLocation,
            Appointment = request.Appointment,
            Establishment = request.Establishment,

            PhotoUrl = request.PhotoUrl,
            BannerPhotoUrl = null,

            Aims = null,
            Description = null,

            CreatedAt = DateTime.Now,
            IsVerified = false,
        });
    }

    private async Task AddUser(User user, CancellationToken cancellationToken)
    {
        if (_context?.Users != null)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}