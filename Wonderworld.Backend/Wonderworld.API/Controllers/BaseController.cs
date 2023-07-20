using Wonderworld.Application.Interfaces;

namespace Wonderworld.API.Controllers;

public class BaseController
{
    private readonly ISharedLessonContext _wonderworldDbContext;

    public BaseController(ISharedLessonContext wonderworldDbContext)
    {
        _wonderworldDbContext = wonderworldDbContext;
    }
    
}