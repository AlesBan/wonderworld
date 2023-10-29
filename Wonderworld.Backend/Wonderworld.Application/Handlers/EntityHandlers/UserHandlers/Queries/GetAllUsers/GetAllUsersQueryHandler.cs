using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly ISharedLessonDbContext _sharedLessonDbContext;

    public GetAllUsersQueryHandler(ISharedLessonDbContext sharedLessonDbContext)
    {
        _sharedLessonDbContext = sharedLessonDbContext;
    }

    public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return _sharedLessonDbContext.Users
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
            .ToListAsync(cancellationToken);
    }
}