using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEstablishment;

public class UpdateUserEstablishmentCommandHandler : IRequestHandler<UpdateUserEstablishmentCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserEstablishmentCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserEstablishmentCommand request, CancellationToken cancellationToken)
    {
        request.User.Institution = request.Establishment;
        
        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}