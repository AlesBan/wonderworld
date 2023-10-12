using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.CreateUserDisciplines;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplinesHandlers.Commands.UpdateUserDisciplines;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserDisciplineHandlers.Commands.
    UpdateUserDisciplines;

public class UpdateUserDisciplinesCommandHandler : IRequestHandler<UpdateUserDisciplinesCommand>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateUserDisciplinesCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateUserDisciplinesCommand request, CancellationToken cancellationToken)
    {
        _context.UserDisciplines
            .RemoveRange(_context.UserDisciplines
                .Where(ud =>
                    ud.UserId == request.UserId));

        
        return await _mediator.Send(new CreateUserDisciplinesCommand
        {
            UserId = request.UserId,
            DisciplineIds = request.NewDisciplineIds
        }, cancellationToken);
    }
}