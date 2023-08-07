using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Interfaces.Services;

public interface IUserManagerService
{
    public User GetUserById(Guid userId);
    public void RegisterUser(User user);
    public void CreateUserAccount(User user);
    public void DeleteUser(User user);
    public void UpdatePhotoUser(User user, string photoUrl);
}