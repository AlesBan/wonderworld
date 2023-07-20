using Wonderworld.Application.Interfaces;

namespace Wonderworld.API.Controllers;

public class BaseController
{
    private readonly IServiceDbContext _wonderworldDbContext;

    public BaseController(IServiceDbContext wonderworldDbContext)
    {
        _wonderworldDbContext = wonderworldDbContext;
    }
    
}