using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;

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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        return await _userAccountService.LoginUser(requestUserDto, Mediator);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        return await _userAccountService.RegisterUser(requestUserDto, Mediator);
    }

    [Authorize]
    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] UserCreateAccountRequestDto requestUserDto)
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.CreateUserAccount(userId, requestUserDto, Mediator);

        return Ok(result);
    }

    [Authorize]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser()
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.DeleteUser(userId, Mediator);

        return Ok(result);
    }
}