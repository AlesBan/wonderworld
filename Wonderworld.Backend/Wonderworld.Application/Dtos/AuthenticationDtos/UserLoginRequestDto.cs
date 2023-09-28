using System.ComponentModel.DataAnnotations;

namespace Wonderworld.Application.Dtos.AuthenticationDtos;

public class UserLoginRequestDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
}