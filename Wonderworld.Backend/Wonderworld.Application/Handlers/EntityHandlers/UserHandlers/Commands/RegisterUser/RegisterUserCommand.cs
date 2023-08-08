using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
}