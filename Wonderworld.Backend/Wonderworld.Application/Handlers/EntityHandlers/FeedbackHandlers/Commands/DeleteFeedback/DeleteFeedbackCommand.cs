using MediatR;
using Wonderworld.Domain.Entities.Communication;

namespace Wonderworld.Application.Handlers.EntityHandlers.FeedbackHandlers.Commands.DeleteFeedback;

public class DeleteFeedbackCommand : IRequest
{
    public Review Feedback { get; set; }
}