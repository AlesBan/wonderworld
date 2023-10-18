using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserVerification;

public class UpdateUserVerificationCommand : IRequest<Unit>
{
    public Guid UserId { get; set; }

    public UpdateUserVerificationCommand(Guid userId)
    {
        UserId = userId;
    }
}