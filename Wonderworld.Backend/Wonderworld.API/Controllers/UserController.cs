using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ISharedLessonDbContext _sharedLessonDbContext;

    public UserController(ISharedLessonDbContext sharedLessonDbContext)
    {
        _sharedLessonDbContext = sharedLessonDbContext;
    }

    [HttpGet]
    public async Task<List<User>> GetAllUsers()
    {
        return await _sharedLessonDbContext.Users.ToListAsync();   
    }
}