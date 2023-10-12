using MediatR;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    DeleteUserDisciplines;

public class DeleteUserDisciplineCommandHandler : IRequestHandler<DeleteUserDisciplineCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteUserDisciplineCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Handles the DeleteUserDisciplineCommand request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteUserDisciplineCommand request, CancellationToken cancellationToken)
    {
        var userDiscipline = _context.UserDisciplines
            .FirstOrDefault(ud =>
                ud.User == request.User &&
                ud.Discipline == request.Discipline);
        
        if (userDiscipline == null)
        {
            throw new NotFoundException(nameof(UserDiscipline), request.User.UserId, request.Discipline.DisciplineId);
        }

        await RemoveUserDisciplines(userDiscipline, cancellationToken);

        return Unit.Value;
    }

    private async Task RemoveUserDisciplines(UserDiscipline userDiscipline,
        CancellationToken cancellationToken)
    {
        _context.UserDisciplines.Remove(userDiscipline);
        await _context.SaveChangesAsync(cancellationToken);
    }
}