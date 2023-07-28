using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommand : IRequest
{
    public User User { get; set; }
    public string NewPassword { get; set; }
}