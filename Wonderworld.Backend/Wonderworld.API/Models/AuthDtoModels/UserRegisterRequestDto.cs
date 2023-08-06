using System.ComponentModel.DataAnnotations;

namespace Wonderworld.API.Models.AuthDtoModels;

public class UserRegisterRequestDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
}