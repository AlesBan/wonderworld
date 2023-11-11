namespace Wonderworld.Application.Dtos.UserDtos.Login;

public class LoginResponseDto
{
    public string AccessToken { get; set; } = string.Empty;
    public bool IsCreatedAccount { get; set; }
}