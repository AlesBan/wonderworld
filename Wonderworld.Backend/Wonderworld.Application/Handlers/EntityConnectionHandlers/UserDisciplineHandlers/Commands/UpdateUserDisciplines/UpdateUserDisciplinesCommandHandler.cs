using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    UpdateUserDisciplines;

public class UpdateUserDisciplinesCommandHandler : IRequestHandler<UpdateUserDisciplinesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserDisciplinesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserDisciplinesCommand request, CancellationToken cancellationToken)
    {
        _context.UserDisciplines
            .RemoveRange(_context.UserDisciplines
                .Where(ud =>
                    ud.UserId == request.UserId));

        var userDisciplines = request.NewDisciplineIds
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