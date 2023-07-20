using MediatR;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Common.Exceptions;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.MediatorHandlers.UserHandlers.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IServiceDbContext _context;

    public DeleteUserCommandHandler(IServiceDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (_context.Users == null)
        {
            throw new DbSetNullException(nameof(User));
            
        }
        
        var user = await _context.Users.FirstOrDefaultAsync(t =>
                t.UserId == request.UserId,
            cancellationToken: cancellationToken);
        
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        await RemoveTeacher(user, cancellationToken);

        return Unit.Value;
    }

    private async Task RemoveTeacher(User teacher, CancellationToken cancellationToken)
    {
        _context.Users?.Remove(teacher);
        await _context.SaveChangesAsync(cancellationToken);
    }
}