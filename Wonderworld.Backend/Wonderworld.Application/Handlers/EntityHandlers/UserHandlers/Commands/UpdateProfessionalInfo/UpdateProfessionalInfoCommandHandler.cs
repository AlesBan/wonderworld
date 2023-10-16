using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Common.Exceptions.User;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserLanguagesHandlers.Commands.UpdateUserLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateProfessionalInfo;

public class UpdateProfessionalInfoCommandHandler : IRequestHandler<UpdateProfessionalInfoCommand, User>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateProfessionalInfoCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<User> Handle(UpdateProfessionalInfoCommand request, CancellationToken cancellationToken)
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

        var languages = await GetLanguages(request.LanguageTitles, cancellationToken);
        
        var disciplines = await GetDisciplines(request.DisciplineTitles, cancellationToken);

        var grades = await GetGrades(request.GradeNumbers, cancellationToken);

        var updateUserLanguagesQuery = new UpdateUserLanguagesCommand
        {
            UserId = user.UserId,
            NewLanguageIds = languages.Select(l => l.LanguageId).ToList()
        };

        var updateUserDisciplinesQuery = new UpdateUserDisciplinesCommand
        {
            UserId = user.UserId,
            NewDisciplineIds = disciplines.Select(d => d.DisciplineId).ToList()
        };

        var updateUserGradesQuery = new UpdateUserGradesCommand()
        {
            UserId = user.UserId,
            NewGradeIds = grades.Select(g => g.GradeId).ToList()
        };

        await _mediator.Send(updateUserLanguagesQuery, cancellationToken);
        await _mediator.Send(updateUserDisciplinesQuery, cancellationToken);
        await _mediator.Send(updateUserGradesQuery, cancellationToken);

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

    private async Task<List<Language>> GetLanguages(IEnumerable<string> languageTitles,
        CancellationToken cancellationToken)
    {
        var query = new GetLanguagesByTitlesQuery(languageTitles);
        var languages = await _mediator.Send(query, cancellationToken);

        return languages;
    }

    private async Task<List<Discipline>> GetDisciplines(IEnumerable<string> disciplineTitles,
        CancellationToken cancellationToken)
    {
        var query = new GetDisciplinesByTitlesQuery(disciplineTitles);
        var disciplines = await _mediator.Send(query, cancellationToken);

        return disciplines;
    }

    private async Task<List<Grade>> GetGrades(IEnumerable<int> gradeNumbers, CancellationToken cancellationToken)
    {
        var query = new GetGradesQuery(gradeNumbers);
        var grades = await _mediator.Send(query, cancellationToken);
        
        return grades;
    }
}