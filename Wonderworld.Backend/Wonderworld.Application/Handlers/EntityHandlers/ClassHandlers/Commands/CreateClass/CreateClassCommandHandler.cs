using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityHandlers.ClassHandlers.Commands.CreateClass;

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateClassCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var newClass = MapClass(request);
        await AddClass(newClass, cancellationToken);

        await SeedClassDisciplines(newClass, request);
        await SeedClassLanguages(newClass, request);
        await _context.SaveChangesAsync(cancellationToken);
        
        return newClass.ClassId;
    }

    private async Task SeedClassLanguages(Class newClass, CreateClassCommand request)
    {
        var classLanguages = request.Languages.Select(lang => new ClassLanguage
        {
            Language = lang,
            Class = newClass
        }).ToList();

        await _context.ClassLanguages.AddRangeAsync(classLanguages);
    }

    private async Task SeedClassDisciplines(Class newClass, CreateClassCommand request)
    {
        var classDisciplines = request.Disciplines.Select(disc => new ClassDiscipline
        {
            Discipline = disc,
            Class = newClass
        }).ToList();

        await _context.ClassDisciplines.AddRangeAsync(classDisciplines);
    }

    private async Task AddClass(Class newClass, CancellationToken cancellationToken)
    {
        await _context.Classes.AddAsync(newClass, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private static Class MapClass(CreateClassCommand request)
    {
        return new Class()
        {
            User = request.User,
            Title = request.Title,
            Grade = request.Grade,
            PhotoUrl = request.PhotoUrl
        };
    }
}