using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces.Services.Data;

public interface IUserDataService
{
    public User GetUserById(Guid userId);
    public void RegisterUser(User user);
    public void CreateUserAccount(User user);
    public void DeleteUser(User user);
}