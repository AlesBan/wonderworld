using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.CreateUserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserAccountCommandHandler(ISharedLessonDbContext serviceDbContext)
    {
        _context = serviceDbContext;
    }

    public async Task<Unit> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        MapUser(user, request);
        SeedUserDisciplines(user, request);

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    private void SeedUserDisciplines(User user, CreateUserAccountCommand request)
    {
        var userDisciplines = request.Disciplines.Select(d => new UserDiscipline
        {
            Discipline = d,
            UserId = user.UserId
        }).ToList();

        _context.UserDisciplines.AddRange(userDisciplines);
    }

    private static void MapUser(User user, CreateUserAccountCommand request)
    {
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.IsATeacher = request.IsATeacher;
        user.IsAnExpert = request.IsAnExpert;
        user.CityLocation = request.CityLocation;
        user.Establishment = request.Establishment;
        user.PhotoUrl = request.PhotoUrl;
    }
}