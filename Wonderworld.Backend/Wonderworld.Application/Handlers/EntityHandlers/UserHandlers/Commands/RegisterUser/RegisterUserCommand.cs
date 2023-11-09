using MediatR;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<User>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}