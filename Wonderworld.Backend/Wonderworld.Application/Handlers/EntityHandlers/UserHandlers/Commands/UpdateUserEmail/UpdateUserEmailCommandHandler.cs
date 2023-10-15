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
        var user = _context.Users
            .Include(u => u.City)
            .Include(u => u.Country)
            .Include(u => u.Institution)
            .Include(u => u.Classes)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages)
            .ThenInclude(ul => ul.Language)
            .FirstOrDefault(u =>
                u.UserId == request.UserId);
        
        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
        
        user.Email = request.Email;
        _context.Users.Attach(user).State = EntityState.Modified;
        
        await _context.SaveChangesAsync(cancellationToken);
        
        user = _context.Users
            .Include(u => u.City)
            .Include(u => u.Country)
            .Include(u => u.Institution)
            .Include(u => u.Classes)
            .ThenInclude(c => c.ClassLanguages)
            .ThenInclude(cl => cl.Language)
            .Include(u => u.Classes)
            .ThenInclude(c => c.ClassDisciplines)
            .ThenInclude(cd => cd.Discipline)
            .Include(u => u.UserDisciplines)
            .ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages)
            .ThenInclude(ul => ul.Language)
            .Include(u => u.UserGrades)
            .ThenInclude(ug => ug.Grade)
            .FirstOrDefault(u =>
                u.UserId == request.UserId);

        return user;
    }
}