using AutoMapper;
using MediatR;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>, IMapWith<User>
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterUserCommand, User>()
            .ForMember(user => user.Email,
                opt => opt.MapFrom(command => command.Email))
            .ForMember(user => user.Password,
                opt => opt.MapFrom(command => command.Password));
    }
}