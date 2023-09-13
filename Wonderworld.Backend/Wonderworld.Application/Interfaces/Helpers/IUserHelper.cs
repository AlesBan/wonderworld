using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces.Helpers;

public interface IUserHelper
{
    public Task<User> GetUserById(Guid userId);
}