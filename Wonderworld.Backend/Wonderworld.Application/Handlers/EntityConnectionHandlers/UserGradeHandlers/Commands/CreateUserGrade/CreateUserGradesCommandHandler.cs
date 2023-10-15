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
        var userGradesAdd = (from gradeId in request.GradeIds 
                let exists = _context.UserGrades.Any(d => 
                    d.GradeId == gradeId && d.UserId == request.UserId) 
                where !exists 
                select new UserGrade() 
                    { UserId = request.UserId, GradeId = gradeId })
            .ToList();

        await _context.UserGrades
            .AddRangeAsync(userGradesAdd, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}