using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Filters;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;
using Wonderworld.Application.Interfaces;

namespace Wonderworld.API.Controllers;

[Produces("application/json")]
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
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _sharedLessonDbContext.Users.ToListAsync());
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        return await _userAccountService.RegisterUser(requestUserDto, Mediator);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        var result = await _userAccountService.LoginUser(requestUserDto, Mediator);
        return result;
    }
    
    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string token)
    {
        return Ok(await _userAccountService.ConfirmEmail(token, Mediator));
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        return Ok(await _userAccountService.ForgotPassword(email, Mediator));
    }

    [Authorize]
    [CheckUserCreateAccountAbility]
    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateUserAccountRequestDto requestUserDto)
    {
        var result = await _userAccountService.CreateUserAccount(UserId, requestUserDto, Mediator);
        return result;
    }


    [Authorize]
    [CheckUserCreateAccount]
    [HttpGet("get-userprofile")]
    public async Task<IActionResult> GetUser()
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.GetUserProfile(userId, Mediator);
        return result;
    }

    [Authorize]
    [CheckUserCreateAccount]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser()
    {
        var result = await _userAccountService.DeleteUser(UserId, Mediator);

        return result;
    }
    
    [HttpDelete("delete-all-users")]
    public async Task<IActionResult> DeleteAllUsers()
    {
        var result = await _userAccountService.DeleteAllUsers(Mediator);

        return result;
    }
}