using System.ComponentModel.DataAnnotations;

namespace Wonderworld.Application.Dtos.UserDtos.ResetPassword;

public class ResetPasswordRequestDto
{
    [Required] public string Password { get; set; } = string.Empty;
}