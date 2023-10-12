using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.CreateClassDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.CreateClassLanguages;
using Wonderworld.Application.Handlers.EntityHandlers.GradeHandlers.Queries.GetGrade;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, Class>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public CreateClassCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Class> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var newClass = await MapClass(request, cancellationToken);
        await AddClassToDb(newClass, cancellationToken);

        await SeedClassDisciplines(newClass, request);
        await SeedClassLanguages(newClass, request);
        await _context.SaveChangesAsync(cancellationToken);

        return newClass;
    }

    private async Task SeedClassLanguages(Class newClass, CreateClassCommand request)
    {
        await _mediator.Send(new CreateClassLanguagesCommand()
        {
            ClassId = newClass.ClassId,
            LanguageIds = request.Languages.Select(lang => lang.LanguageId).ToList()
        }, CancellationToken.None);
    }

    private async Task SeedClassDisciplines(Class newClass, CreateClassCommand request)
    {
        await _mediator.Send(new CreateClassDisciplinesCommand()
        {
            ClassId = newClass.ClassId,
            DisciplineIds = request.Disciplines.Select(discipline => discipline.DisciplineId).ToList()
        }, CancellationToken.None);
    }

    private async Task AddClassToDb(Class newClass, CancellationToken cancellationToken)
    {
        await _context.Classes.AddAsync(newClass, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task<Class> MapClass(CreateClassCommand request, CancellationToken cancellationToken)
    {
        return new Class()
        {
            UserId = request.UserId,
            Title = request.Title,
            Grade = await _mediator.Send(new GetGradeQuery(request.GradeNumber), cancellationToken),
            PhotoUrl = request.PhotoUrl
        };
    }
}