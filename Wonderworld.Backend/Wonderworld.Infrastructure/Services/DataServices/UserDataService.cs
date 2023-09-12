using Wonderworld.Application.Interfaces;
using Wonderworld.Application.Interfaces.Services.Data;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.DataServices;

public class UserDataService : IUserDataService
{
    private readonly ISharedLessonDbContext _context;

    public UserDataService(ISharedLessonDbContext context)
    {
        _context = context;
    }

    public User GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void RegisterUser(User user)
    {
        throw new NotImplementedException();
    }

    public void CreateUserAccount(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

}