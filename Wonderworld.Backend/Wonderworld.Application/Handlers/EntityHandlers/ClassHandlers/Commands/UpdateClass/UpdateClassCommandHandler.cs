using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.UpdateClassDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.UpdateClassLanguages;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrade;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrades;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, Class>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateClassCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Class> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var @class = await _context.Classes
            .FirstOrDefaultAsync(c => c.ClassId == request.ClassId, cancellationToken: cancellationToken);

        if (@class == null)
        {
            throw new NotFoundException(nameof(Class), request.ClassId);
        }

        @class.Title = request.Title;
        @class.Grade = await _mediator.Send(new GetGradeQuery(request.GradeNumber), cancellationToken);

        await _mediator.Send(new UpdateClassDisciplinesCommand()
        {
            ClassId = @class.ClassId,
            NewDisciplineIds = request.Disciplines.Select(discipline =>
                discipline.DisciplineId).ToList()
        }, cancellationToken);


        await _mediator.Send(new UpdateClassLanguagesCommand()
        {
            ClassId = @class.ClassId,
            NewLanguageIds = request.Languages.Select(language =>
                language.LanguageId).ToList()
            
        }, cancellationToken);

        @class.PhotoUrl = request.PhotoUrl;

        _context.Classes.Attach(@class).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return @class;
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