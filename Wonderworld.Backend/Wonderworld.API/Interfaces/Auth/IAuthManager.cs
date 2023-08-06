using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Interfaces.Auth;

public interface IAuthService
{
    void SetToken(User user, HttpContext httpContext, IConfiguration configuration);
}