using System.ComponentModel.DataAnnotations;

namespace Wonderworld.Application.Dtos.AuthenticationDto;

public class UserRegisterRequestDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
}