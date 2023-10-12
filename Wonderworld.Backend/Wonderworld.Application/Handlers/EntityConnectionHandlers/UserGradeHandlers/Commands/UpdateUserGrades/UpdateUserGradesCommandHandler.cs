using AutoMapper;
using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.CreateUserGrade;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.UserGradeHandlers.Commands.UpdateUserGrades;

public class UpdateUserGradesCommandHandler : IRequestHandler<UpdateUserGradesCommand>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateUserGradesCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateUserGradesCommand request, CancellationToken cancellationToken)
    {
        _context.UserGrades
            .RemoveRange(_context.UserGrades
                .Where(ug =>
                    ug.User.UserId == request.UserId));

        return await _mediator.Send(new CreateUserGradesCommand()
        {
            UserId = request.UserId,
            GradeIds = request.NewGradeIds

        }, cancellationToken);
    }
}