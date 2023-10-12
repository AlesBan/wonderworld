using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassDisciplineHandlers.Commands.
    CreateClassDisciplines;

public class CreateClassDisciplinesCommandHandler : IRequestHandler<CreateClassDisciplinesCommand, Unit>
{
    private readonly ISharedLessonDbContext _context;

    public CreateClassDisciplinesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateClassDisciplinesCommand request, CancellationToken cancellationToken)
    {
        var classDisciplines = request.DisciplineIds
            .Select(discipline =>
                new ClassDiscipline()
                {
                    ClassId = request.ClassId,
                    DisciplineId = discipline
                });

        await _context.ClassDisciplines
            .AddRangeAsync(classDisciplines, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}