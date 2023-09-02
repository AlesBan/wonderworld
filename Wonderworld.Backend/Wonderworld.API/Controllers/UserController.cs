using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;

public class UserController : BaseController
{
    private readonly ISharedLessonDbContext _sharedLessonDbContext;

    public UserController(ISharedLessonDbContext sharedLessonDbContext)
    {
        _sharedLessonDbContext = sharedLessonDbContext;
    }

    [HttpGet("all-users")]
    public async Task<List<User>> GetAllUsers()
    {
        
        return await _sharedLessonDbContext.Users.ToListAsync();   
    }
}