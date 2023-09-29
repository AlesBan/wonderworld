using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Dtos.AuthenticationDtos;

namespace Wonderworld.API.Controllers;

public class AuthenticationController : BaseController
{
    private readonly IUserAccountService _userAccountService;

    public AuthenticationController(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        if (StateHelper.CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        {
            return modelStateValidationResult;
        }

        return await _userAccountService.LoginUser(requestUserDto, Mediator);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        if (StateHelper.CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        {
            return modelStateValidationResult;
        }

        return await _userAccountService.RegisterUser(requestUserDto, Mediator);
    }
}