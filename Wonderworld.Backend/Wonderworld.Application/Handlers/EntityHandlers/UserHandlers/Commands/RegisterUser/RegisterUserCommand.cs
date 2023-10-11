using MediatR;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<User>
{
    public UserRegisterRequestDto UserRegister { get; set; }

    public RegisterUserCommand(UserRegisterRequestDto userRegisterRequestDto)
    {
        UserRegister = userRegisterRequestDto;
    }

    public RegisterUserCommand(string email, string password)
    {
        UserRegister = new UserRegisterRequestDto { Email = email, Password = password };
    }
}