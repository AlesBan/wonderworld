using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    CreateUserDisciplines;

public class CreateUserDisciplineCommandHandler : IRequestHandler<CreateUserDisciplineCommand>
{
    private readonly ISharedLessonDbContext _context;

    public CreateUserDisciplineCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateUserDisciplineCommand request, CancellationToken cancellationToken)
    {
        var userDiscipline = new UserDiscipline
        {
            Discipline = request.Discipline,
            User = request.User
        };

        _context.UserDisciplines.AddRange(userDiscipline);
       await _context.SaveChangesAsync(cancellationToken);

       return Unit.Value;
    }
}