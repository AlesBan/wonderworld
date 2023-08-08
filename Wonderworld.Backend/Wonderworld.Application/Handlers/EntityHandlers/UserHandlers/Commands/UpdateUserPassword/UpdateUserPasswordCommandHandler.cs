using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler: IRequestHandler<UpdateUserPasswordCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserPasswordCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        request.User.Password = request.NewPassword;
        
        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}