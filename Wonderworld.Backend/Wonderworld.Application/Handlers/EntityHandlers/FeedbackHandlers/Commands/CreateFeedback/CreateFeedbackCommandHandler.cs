using MediatR;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.CreateFeedback;

public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Guid>
{
    private readonly ISharedLessonDbContext _context;

    public CreateFeedbackCommandHandler(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = new Review()
        {
            Invitation = request.Invitation,
            WasTheJointLesson = request.WasTheJointLesson,
            ReasonForNotConducting = request.ReasonForNotConducting,
            ReviewText = request.FeedbackText,
            Rating = request.Rating
        };

        _context.Reviews.Add(feedback);
        await _context.SaveChangesAsync(cancellationToken);

        return feedback.ReviewId;
    }
}