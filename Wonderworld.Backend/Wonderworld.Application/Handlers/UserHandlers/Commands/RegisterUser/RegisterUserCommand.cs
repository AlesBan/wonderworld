using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Interface;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>, IMapWith<User>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public InterfaceLanguage InterfaceLanguage { get; set; }

}