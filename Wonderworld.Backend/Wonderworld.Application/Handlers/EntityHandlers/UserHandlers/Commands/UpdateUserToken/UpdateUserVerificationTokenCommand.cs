using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserToken;

public class UpdateUserVerificationTokenCommand : IRequest<User>
{
    public Guid UserId { get; set; }
    public string VerificationToken { get; set; }

    public UpdateUserVerificationTokenCommand(Guid userId, string verificationToken)
    {
        UserId = userId;
        VerificationToken = verificationToken;
    }
}