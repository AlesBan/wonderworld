using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;

public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserEmailCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
    {
        request.User.Email = request.NewEmail;

        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}