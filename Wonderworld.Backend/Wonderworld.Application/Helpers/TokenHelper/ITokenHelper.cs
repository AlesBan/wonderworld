using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Helpers.TokenHelper;

public interface ITokenHelper
{
    public string CreateToken(User user);
}