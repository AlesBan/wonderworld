using Wonderworld.Application.Interfaces;

namespace Wonderworld.API.Controllers;

public class BaseController
{
    private readonly IWonderworldDbContext _wonderworldDbContext;

    public BaseController(IWonderworldDbContext wonderworldDbContext)
    {
        _wonderworldDbContext = wonderworldDbContext;
    }
    
}