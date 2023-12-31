using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Filters;
using Wonderworld.API.Helpers;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.Application.Dtos.UserDtos.Authentication;
using Wonderworld.Application.Dtos.UserDtos.CreateAccount;
using Wonderworld.Application.Dtos.UserDtos.ResetPassword;
using Wonderworld.Infrastructure.Services.AccountServices;

namespace Wonderworld.API.Controllers;

[Produces("application/json")]
public class UserController : BaseController
{
    private readonly IUserAccountService _userAccountService;

    public UserController(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userAccountService.GetAllUsers(Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        var result = await _userAccountService.RegisterUser(requestUserDto, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        var result = await _userAccountService.LoginUser(requestUserDto, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string verificationCode)
    {
        var result = await _userAccountService.ConfirmEmail(UserId, verificationCode, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [Authorize]
    [CheckUserCreateAccountAbility]
    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateUserAccountRequestDto requestUserDto)
    {
        var result = await _userAccountService.CreateUserAccount(UserId, requestUserDto, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        var result = await _userAccountService.ForgotPassword(email, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [HttpPost("check-reset-password-code")]
    public async Task<IActionResult> CheckResetPasswordCode(string code)
    {
        await _userAccountService.CheckResetPasswordCode(UserId, code, Mediator);
        return ResponseHelper.GetOkResult();
    }

    [Authorize]
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto requestDto)
    {
        var result = await _userAccountService
            .ResetPassword(UserId, requestDto, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [Authorize]
    [CheckUserCreateAccount]
    [HttpGet("get-userprofile")]
    public async Task<IActionResult> GetUser()
    {
        var userId = JwtHelper.GetUserIdFromClaims(HttpContext);
        var result = await _userAccountService.GetUserProfile(userId, Mediator);
        return ResponseHelper.GetOkResult(result);
    }

    [Authorize]
    [CheckUserCreateAccount]
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser()
    {
        await _userAccountService.DeleteUser(UserId, Mediator);
        return Ok();
    }

    [HttpDelete("delete-all-users")]
    public async Task<IActionResult> DeleteAllUsers()
    {
        await _userAccountService.DeleteAllUsers(Mediator);
        return Ok();
    }
}