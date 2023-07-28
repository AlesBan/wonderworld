using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEmail;

public class UpdateUserEmailCommand : IRequest
{
    public User User { get; set; }
    public string NewEmail { get; set; }
}