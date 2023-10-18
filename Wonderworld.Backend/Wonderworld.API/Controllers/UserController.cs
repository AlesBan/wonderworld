using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    /// <summary>
    /// Gets all users
    /// </summary>
    /// <remarks>
    ///GET /api/user/all-users
    /// </remarks>
    /// <returns>
    ///Returns List of User
    /// </returns>
    /// <response code="200">Returns List of User</response>
    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _sharedLessonDbContext.Users.ToListAsync());
    }

    /// <summary>
    /// Register` user
    /// </summary>
    /// <remarks>
    /// POST /api/user/register
    /// </remarks>
    /// <param name="requestUserDto">UserRegisterRequestDto object</param>
    /// <returns>
    /// AuthResult object
    /// /// </returns>
    /// <response code="200">Returns AuthResult object</response>
    /// <response code="400">Returns BadRequest object</response> 
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        return await _userAccountService.RegisterUser(requestUserDto, Mediator);
    }

    /// <summary>
    /// Login user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="requestUserDto">UserLoginRequestDto object</param>
    /// <returns>
    /// AuthResult object
    /// </returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        var result = await _userAccountService.LoginUser(requestUserDto, Mediator);
        return result;
    }

    /// <summary>
    /// Verify email
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        return Ok(await _userAccountService.VerifyEmail(token, Mediator));
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        return Ok(await _userAccountService.ForgotPassword(email, Mediator));
    }

    /// <summary>
    /// Create account
    /// </summary>
    /// <remarks>
    /// POST /api/user/create-account
    /// </remarks>
    /// <param name="requestUserDto"></param>
    /// <returns>
    /// AuthResult object
    /// </returns>
    /// <response code="200">Returns AuthResult object</response>
    /// <response code="400">Returns ResponseResult object</response>
    /// <response code="401">Returns Unauthorized object</response>
    [Authorize]
    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateUserAccountRequestDto requestUserDto)
    {
        var result = await _userAccountService.CreateUserAccount(UserId, requestUserDto, Mediator);
        return result;
    }

    /// <summary>
    /// Get user profile
    /// </summary>
    /// <remarks>
    /// GET /api/user/get-userprofile
    /// </remarks>
    /// <returns>
    /// Returns UserProfileDto
    /// </returns>
    /// <response code="200">Returns UserProfileDto</response>
    /// <response code="400">Returns ResponseResult object</response>
    /// <response code="401">Returns Unauthorized object</response>
    [Authorize]
    [HttpGet("get-userprofile")]
    public async Task<IActionResult> GetUser()
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.GetUserProfile(userId, Mediator);
        return result;
    }

    /// <summary>
    /// Delete user
    /// </summary>
    /// <remarks>
    /// DELETE /api/user/delete-user
    /// </remarks>
    /// <returns>
    /// No content
    /// </returns>
    /// <response code="200">Returns AuthResult object</response>
    /// <response code="400">Returns ResponseResult object</response>
    /// <response code="401">Returns Unauthorized object</response>
    [Authorize]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser()
    {
        var result = await _userAccountService.DeleteUser(UserId, Mediator);

        return result;
    }
}