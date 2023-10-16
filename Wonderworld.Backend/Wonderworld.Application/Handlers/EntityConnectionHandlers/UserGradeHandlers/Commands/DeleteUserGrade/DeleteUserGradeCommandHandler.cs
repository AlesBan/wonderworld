using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Common.Exceptions.Common;
using Wonderworld.Application.Common.Exceptions.Database;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.DeleteUserGrade;

public class DeleteUserGradeCommandHandler : IRequestHandler<DeleteUserGradeCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteUserGradeCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserGradeCommand request, CancellationToken cancellationToken)
    {
        var userGrade = await _context.UserGrades.FirstOrDefaultAsync(ug =>
                ug.User == request.User &&
                ug.Grade == request.Grade,
            cancellationToken);

        if (userGrade == null)
        {
            throw new NotFoundException(nameof(UserGrade), request.User.UserId, request.Grade.GradeId);
        }

        _context.UserGrades.Remove(userGrade);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}