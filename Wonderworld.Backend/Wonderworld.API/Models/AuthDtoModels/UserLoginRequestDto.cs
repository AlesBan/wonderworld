using System.ComponentModel.DataAnnotations;

namespace Wonderworld.API.Models.AuthDtoModels;

public class UserLoginRequestDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
}