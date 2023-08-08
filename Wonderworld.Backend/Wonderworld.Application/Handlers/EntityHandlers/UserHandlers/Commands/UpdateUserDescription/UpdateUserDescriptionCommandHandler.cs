using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserDescription;

public class UpdateUserDescriptionCommandHandler : IRequestHandler<UpdateUserDescriptionCommand>
{
    private readonly ISharedLessonDbContext _context;

    public UpdateUserDescriptionCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserDescriptionCommand request, CancellationToken cancellationToken)
    {
        request.User.Description = request.Description;

        _context.Users.Update(request.User);
        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(Unit.Value);
    }
}