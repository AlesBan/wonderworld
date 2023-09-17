using Wonderworld.Application.Interfaces;
using Wonderworld.Application.Interfaces.Services;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Infrastructure.Services.AccountServices;

public class UserAccountService : IUserAccountService
{
    private readonly ISharedLessonDbContext _context;

    public UserAccountService(ISharedLessonDbContext context)
    {
        _context = context;
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