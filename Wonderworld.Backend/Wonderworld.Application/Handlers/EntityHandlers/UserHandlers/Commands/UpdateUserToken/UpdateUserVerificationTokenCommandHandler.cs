using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserToken;

public class UpdateUserVerificationTokenCommandHandler : IRequestHandler<UpdateUserVerificationTokenCommand, User>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserVerificationTokenCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(UpdateUserVerificationTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        if (user == null)
            throw new UserNotFoundException(request.UserId);

        user.AccessToken = request.VerificationToken;

        await _context.SaveChangesAsync(cancellationToken);

        var verifiedUser = _context
            .Users
            .Include(u => u.Country)
            .Include(u => u.City)
            .Include(u => u.Institution)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages)
            .ThenInclude(ul => ul.Language)
            .Include(u => u.UserGrades)
            .ThenInclude(ug => ug.Grade)
            .FirstOrDefault(u => u.UserId == request.UserId);
        
        return verifiedUser!;
    }
}