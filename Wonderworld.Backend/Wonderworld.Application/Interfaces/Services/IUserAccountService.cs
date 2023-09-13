using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces.Services;

public interface IUserAccountService
{
    public void RegisterUser(User user);
    public void CreateUserAccount(User user);
    public void DeleteUser(User user);
}