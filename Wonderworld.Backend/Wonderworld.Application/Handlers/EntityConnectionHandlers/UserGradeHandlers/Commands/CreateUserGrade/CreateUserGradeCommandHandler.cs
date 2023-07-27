using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;

public class CreateUserGradeCommandHandler : IRequestHandler<CreateUserGradeCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserGradeCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserGradeCommand request, CancellationToken cancellationToken)
    {
        var userGrade = new UserGrade()
        {
            Grade = request.Grade,
            User = request.User
        };

        await _context.UserGrades.AddAsync(userGrade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}