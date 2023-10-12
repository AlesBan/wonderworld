using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    CreateUserDisciplines;

public class CreateUserDisciplinesCommandHandler : IRequestHandler<CreateUserDisciplinesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserDisciplinesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserDisciplinesCommand request, CancellationToken cancellationToken)
    {
        var userDisciplines = request.DisciplineIds
            .Select(discipline =>
                new UserDiscipline()
                {
                    UserId = request.UserId,
                    DisciplineId = discipline
                });

        await _context.UserDisciplines
            .AddRangeAsync(userDisciplines, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}