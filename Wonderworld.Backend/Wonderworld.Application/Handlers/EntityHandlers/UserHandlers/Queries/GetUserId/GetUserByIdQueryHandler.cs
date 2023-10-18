using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUser;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly ISharedLessonDbContext _context;

    public GetUserByIdQueryHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Country)
            .Include(u => u.City)
            .Include(u => u.Institution)
            .FirstOrDefaultAsync(u =>
            u.UserId == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
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