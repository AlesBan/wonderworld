using MediatR;
using Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.CreateClassLanguages;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityConnectionHandlers.ClassLanguagesHandlers.Commands.
    UpdateClassLanguages;

public class UpdateClassLanguagesCommandHandler : IRequestHandler<UpdateClassLanguagesCommand>
{
    private readonly ISharedLessonDbContext _context;
    private readonly IMediator _mediator;

    public UpdateClassLanguagesCommandHandler(ISharedLessonDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateClassLanguagesCommand request, CancellationToken cancellationToken)
    {
        var classLanguages = _context.ClassLanguages
            .Where(cl =>
                cl.ClassId == request.ClassId);

        _context.ClassLanguages
            .RemoveRange(classLanguages);

        return await _mediator.Send(new CreateClassLanguagesCommand()
        {
            ClassId = request.ClassId,
            LanguageIds = request.NewLanguageIds
        }, cancellationToken);
    }
}