using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.AuthenticationDtos;

public class UserRegisterRequestDto : IMapWith<User>
{
    [Required] public string Email => string.Empty;

    [Required] public string Password => string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserRegisterRequestDto, User>()
            .ForMember(u => u.Email, opt => 
                opt.MapFrom(ur => ur.Email))
            .ForMember(u => u.Password, opt => 
                opt.MapFrom(ur => ur.Password));
    }
}