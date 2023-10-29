using MediatR;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<User>
{
    public UserRegisterRequestDto RegisterRequestDto { get; set; }

    public RegisterUserCommand(UserRegisterRequestDto requestUserDto)
    {
        RegisterRequestDto = requestUserDto;
    }
}