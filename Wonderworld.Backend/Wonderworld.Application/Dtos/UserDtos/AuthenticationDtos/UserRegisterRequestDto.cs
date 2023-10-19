using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Wonderworld.Application.Common.Mappings;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;

public class UserRegisterRequestDto : IMapWith<User>
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] public string Password { get; set; } = string.Empty;
    
}