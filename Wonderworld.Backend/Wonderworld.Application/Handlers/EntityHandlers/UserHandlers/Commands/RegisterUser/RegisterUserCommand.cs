using MediatR;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<User>
{
    public User User { get; set; }

    public RegisterUserCommand(User user)
    {
        User = user;
    }
}