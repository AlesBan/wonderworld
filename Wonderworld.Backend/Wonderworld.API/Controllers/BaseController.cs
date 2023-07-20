using Wonderworld.Application.Interfaces;

namespace Wonderworld.API.Controllers;

public class BaseController
{
    private readonly ISharedLessonDbContext _wonderworldDbContext;

    public BaseController(ISharedLessonDbContext wonderworldDbContext)
    {
        _wonderworldDbContext = wonderworldDbContext;
    }
    
}