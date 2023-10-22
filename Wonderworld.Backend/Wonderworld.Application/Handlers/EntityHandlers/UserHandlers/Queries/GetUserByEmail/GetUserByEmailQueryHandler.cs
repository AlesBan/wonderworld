using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly ISharedLessonDbContext _context;

    public GetUserByEmailQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                x.Email == request.Email, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.Email);
        }

        user = await _context.Users
            .Include(u => u.City)
            .Include(u => u.Country)
            .Include(u => u.Institution)
            .Include(u => u.Classes)
            .ThenInclude(c => c.ClassLanguages)
            .ThenInclude(cl => cl.Language)
            .Include(u => u.Classes)
            .ThenInclude(c => c.ClassDisciplines)
            .ThenInclude(cd => cd.Discipline)
            .Include(u => u.Classes)
            .ThenInclude(cg => cg.Grade)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages)
            .ThenInclude(ul => ul.Language)
            .Include(u => u.UserGrades)
            .ThenInclude(ug => ug.Grade)
            .FirstOrDefaultAsync(u =>
                u.UserId == user.UserId, cancellationToken: cancellationToken);
        
        return user;
    }
}