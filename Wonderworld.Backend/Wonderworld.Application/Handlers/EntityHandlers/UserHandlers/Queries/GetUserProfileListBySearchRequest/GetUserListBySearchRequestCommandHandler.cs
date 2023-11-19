using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetUserProfileListBySearchRequest;

public class GetUserListBySearchRequestCommandHandler : IRequestHandler<
    GetUserListBySearchRequestCommand, IEnumerable<User>>
{
    private readonly ISharedLessonDbContext _context;

    public GetUserListBySearchRequestCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<User>> Handle(GetUserListBySearchRequestCommand request,
        CancellationToken cancellationToken)
    {
        var searchRequest = request.SearchRequest;
        var countryTitles = searchRequest.Countries;
        var gradeNumbers = searchRequest.Grades;
        var disciplineTitles = searchRequest.Disciplines;
        var languageTitles = searchRequest.Languages;
        var userIdToExclude = searchRequest.UserId;

        var users = _context.Users
            .Include(u => u.City)
            .Include(u => u.Country)
            .Include(u => u.Institution)
            .Include(u => u.Classes).ThenInclude(c => c.ClassLanguages).ThenInclude(cl => cl.Language)
            .Include(u => u.Classes).ThenInclude(c => c.ClassDisciplines).ThenInclude(cd => cd.Discipline)
            .Include(u => u.Classes).ThenInclude(cg => cg.Grade)
            .Include(u => u.UserDisciplines).ThenInclude(ud => ud.Discipline)
            .Include(u => u.UserLanguages).ThenInclude(ul => ul.Language)
            .Include(u => u.UserGrades).ThenInclude(ug => ug.Grade)
            .Where(u =>
                u.UserId != userIdToExclude && (
                    u.Country != null && countryTitles.Contains(u.Country.Title) ||
                    u.UserGrades.Any(ug => gradeNumbers.Contains(ug.Grade.GradeNumber.ToString())) ||
                    u.UserDisciplines.Any(d => disciplineTitles.Contains(d.Discipline.Title)) ||
                    u.UserLanguages.Any(l => languageTitles.Contains(l.Language.Title))));

        return Task.FromResult<IEnumerable<User>>(users);
    }
}