namespace Wonderworld.API.Models;

public class UserToken
{
    public Guid UserId { get; set; }

    public string AccessToken { get; set; }
    
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public TimeSpan Validaty { get; set; }
    public string RefreshToken { get; set; }
    
    public string UserMessage { get; set; }

    public Guid GuidId { get; set; }
    public DateTime ExpiredTime { get; set; }
}