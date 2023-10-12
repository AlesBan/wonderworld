using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;

public class CreateUserGradesCommandHandler : IRequestHandler<CreateUserGradesCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserGradesCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserGradesCommand request, CancellationToken cancellationToken)
    {
        var userGradesAdd = request.GradeIds
            .Select(g =>
                new UserGrade
                {
                    GradeId = g,
                    UserId = request.UserId,
                });

        await _context.UserGrades
            .AddRangeAsync(userGradesAdd, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}