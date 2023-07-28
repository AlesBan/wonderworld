using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.UpdateClass;

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateClassCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        MapClass(request.Class, request);

        _context.Classes.Update(request.Class);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private static void MapClass(Class @class, UpdateClassCommand request)
    {
        @class.Title = request.Title;
        @class.Grade = request.Grade;
        @class.Age = request.Age;

        @class.ClassDisciplines = request.Disciplines.Select(disc => new ClassDiscipline
        {
            Discipline = disc,
            Class = @class
        }).ToList();

        @class.ClassLanguages = request.Languages.Select(lang => new ClassLanguage
        {
            Language = lang,
            Class = @class
        }).ToList();

        @class.PhotoUrl = request.PhotoUrl;
    }

    private async void UpdateDisciplines(Class @class, UpdateClassCommand request)
    {
        var classDisciplines = await _context.ClassDisciplines.FirstOrDefaultAsync(cd =>
            cd.ClassId == @class.ClassId);

        if (classDisciplines != null)
        {
            _context.ClassDisciplines.RemoveRange(classDisciplines);
        }

        var classDisciplinesToAdd = request.Disciplines.Select(disc => new ClassDiscipline
        {
            Discipline = disc,
            Class = @class
        });
    }
}

