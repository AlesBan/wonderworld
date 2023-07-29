using MediatR;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.DeleteFeedback;

public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand>
{
    private readonly ISharedLessonDbContext _context;

    public DeleteFeedbackCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        _context.Feedbacks.Remove(request.Feedback);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}