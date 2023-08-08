using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;

public class UpdateUserGradesCommandHandler: IRequestHandler<UpdateUserGradesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserGradesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserGradesCommand request, CancellationToken cancellationToken)
    {
        _context.UserGrades
            .RemoveRange(_context.UserGrades
                .Where(ug =>
                    ug.User == request.User));

        var userGrades = request.NewGrades.Select(grade =>
            new UserGrade()
            {
                User = request.User,
                Grade = grade
            });

        await _context.UserGrades.AddRangeAsync(userGrades, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}