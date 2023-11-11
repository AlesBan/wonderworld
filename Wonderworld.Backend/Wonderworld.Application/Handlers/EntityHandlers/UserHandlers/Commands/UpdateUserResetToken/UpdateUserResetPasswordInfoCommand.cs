using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserResetToken;

public class UpdateUserResetPasswordInfoCommand : IRequest<User>
{
    public Guid UserId { get; set; }

    public UpdateUserResetPasswordInfoCommand(Guid userId)
    {
        UserId = userId;
    }
}