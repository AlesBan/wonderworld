using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;

[Authorize]
public class UserController : BaseController
{
    private readonly ISharedLessonDbContext _sharedLessonDbContext;
    private readonly IUserAccountService _userAccountService;

    public UserController(ISharedLessonDbContext sharedLessonDbContext, IUserAccountService userAccountService)
    {
        _sharedLessonDbContext = sharedLessonDbContext;
        _userAccountService = userAccountService;
    }

    [HttpGet("all-users")]
    public async Task<List<User>> GetAllUsers()
    {
        return await _sharedLessonDbContext.Users.ToListAsync();
    }

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] UserCreateAccountRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.CreateUserAccount(userId, requestUserDto, Mediator);

        return Ok(result);
    }
}