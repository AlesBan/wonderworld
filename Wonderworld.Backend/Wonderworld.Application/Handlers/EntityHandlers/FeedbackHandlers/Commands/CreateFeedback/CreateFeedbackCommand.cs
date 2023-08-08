using MediatR;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.CreateFeedback;

public class CreateFeedbackCommand : IRequest<Guid>
{
    public Invitation Invitation { get; set; }
    public bool WasTheJointLesson { get; set; }
    public string? ReasonForNotConducting { get; set; }
    public string? FeedbackText { get; set; }
    public int Rating { get; set; }
}