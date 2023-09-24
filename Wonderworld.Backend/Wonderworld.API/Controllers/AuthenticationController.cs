using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models.Authentication;
using Wonderworld.Application.Dtos.AuthenticationDto;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;
using static Wonderworld.API.Constants.AuthConstants;

namespace Wonderworld.API.Controllers;

public class AuthenticationController : BaseController
{
    private readonly ISharedLessonDbContext _sharedLessonDbContext;
    private readonly IConfiguration _configuration;

    public AuthenticationController(ISharedLessonDbContext sharedLessonDbContext, IConfiguration configuration)
    {
        _sharedLessonDbContext = sharedLessonDbContext;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        if (CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        {
            return modelStateValidationResult;
        }

        var userValidationResult = await CheckLoginUser(requestUserDto);

        switch (userValidationResult)
        {
            case BadRequestObjectResult badRequestResult:
                return badRequestResult;
            case OkObjectResult okResult:

                if (okResult.Value is not User user)
                {
                    return StatusCode(500);
                }

                var token = JwtHelper.CreateToken(user, _configuration);

                return Ok(new AuthResult()
                {
                    Result = true,
                    Token = token
                });
            default:
                return StatusCode(500);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        if (CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        {
            return modelStateValidationResult;
        }

        var userValidationResult = await CheckRegisterUser(requestUserDto);

        switch (userValidationResult)
        {
            case BadRequestObjectResult badRequestResult:
                return badRequestResult;
            case OkObjectResult okResult:
                if (okResult.Value is not User user)
                {
                    return StatusCode(500);
                }

                await _sharedLessonDbContext.Users.AddAsync(user);
                await _sharedLessonDbContext.SaveChangesAsync(CancellationToken.None);

                var token = JwtHelper.CreateToken(user, _configuration);

                return Ok(new AuthResult
                {
                    Result = true,
                    Token = token
                });
            default:
                return StatusCode(500);
        }
    }

    private IActionResult CheckModelState(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        return Ok();
    }

    private async Task<IActionResult> CheckLoginUser(UserLoginRequestDto requestUserDto)
    {
        var existingUser = await _sharedLessonDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == requestUserDto.Email);

        if (existingUser == null)
        {
            return BadRequest(new AuthResult
            {
                Result = false,
                Errors = new List<string> { UserNotFoundErrorMessage }
            });
        }

        var isCorrectPassword = existingUser.Password == requestUserDto.Password;

        if (!isCorrectPassword)
        {
            return BadRequest(new AuthResult
            {
                Result = false,
                Errors = new List<string> { InvalidCredentialsErrorMessage }
            });
        }

        return Ok(existingUser);
    }

    private async Task<IActionResult> CheckRegisterUser(UserRegisterRequestDto requestUserDto)
    {
        var existingUser = await _sharedLessonDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == requestUserDto.Email);

        if (existingUser != null)
        {
            return BadRequest(new AuthResult
            {
                Result = false,
                Errors = new List<string>
                {
                    UserExistsErrorMessage
                }
            });
        }

        var user = new User
        {
            Email = requestUserDto.Email,
            Password = requestUserDto.Password
        };

        return Ok(user);
    }
}