using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.UpdateClassDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.UpdateClassLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Queries.GetClass;
using Wonderworld.Application.Handlers.EntityHandlers.DisciplineHandlers.Queries.GetDisciplines;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrade;
using Wonderworld.Application.Handlers.EntityHandlers.LanguageHandlers.Queries.GetLanguagesByTitles;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Education;
using Wonderworld.Domain.Entities.Main;
using static System.Threading.Tasks.Task;

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
        
        var grade = await GetGrade(request.GradeNumber, cancellationToken);
        @class.GradeId = grade.GradeId;

        await Delay(20, cancellationToken);

        var disciplines = await GetDisciplines(request.DisciplineTitles, cancellationToken);
        await _mediator.Send(new UpdateClassDisciplinesCommand()
        {
            ClassId = @class.ClassId,
            NewDisciplineIds = disciplines.Select(discipline =>
                discipline.DisciplineId).ToList()
        }, cancellationToken);

        await Delay(20, cancellationToken);

        var languages = await GetLanguages(request.LanguageTitles, cancellationToken);
        await _mediator.Send(new UpdateClassLanguagesCommand()
        {
            ClassId = @class.ClassId,
            NewLanguageIds = languages.Select(language =>
                language.LanguageId).ToList()
            
        }, cancellationToken);

        @class.PhotoUrl = request.PhotoUrl;

        await Delay(20, cancellationToken);

        _context.Classes.Attach(@class).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return await _mediator.Send(new GetClassCommand(@class.ClassId), cancellationToken);
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

    private async Task<Grade> GetGrade(int gradeNumber, CancellationToken cancellationToken)
    {
        var query = new GetGradeQuery(gradeNumber);
        var grades = await _mediator.Send(query, cancellationToken);

        return grades;
    }
}