using Microsoft.AspNetCore.Mvc;
using Wonderworld.API.Helpers;
using Wonderworld.API.Services.AccountServices;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Helpers.JwtHelpers;
using Wonderworld.API.Models.AuthDtoModels;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;


[ApiController]
public class AuthenticationController : BaseController
{
    private readonly IUserAccountService _userAccountService;
    private readonly ISharedLessonDbContext _sharedLessonDbContext;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IUserAccountService userAccountService)
    public AuthenticationController(ISharedLessonDbContext sharedLessonDbContext, IConfiguration configuration)
    {
        _userAccountService = userAccountService;
        _sharedLessonDbContext = sharedLessonDbContext;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestUserDto)
    {
        if (StateHelper.CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        if (!ModelState.IsValid)
        {
            return modelStateValidationResult;
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        var existingUser = await _sharedLessonDbContext.Users
            .FirstOrDefaultAsync(u =>
                u.Email == requestUserDto.Email
            );

        if (existingUser == null)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "User not found"
                }
            });
        }

        var isCorrectPassword = existingUser.Password == requestUserDto.Password;

        if (!isCorrectPassword)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid credentials"
                }
            });
        }

        return await _userAccountService.LoginUser(requestUserDto, Mediator);
        var token = JwtHelper.CreateToken(existingUser, _configuration);

        return Ok(new AuthResult()
        {
            Result = true,
            Token = token
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        if (StateHelper.CheckModelState(ModelState) is BadRequestObjectResult modelStateValidationResult)
        if (!ModelState.IsValid)
        {
            return modelStateValidationResult;
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }

        return await _userAccountService.RegisterUser(requestUserDto, Mediator);
    }
}
        var userExists = await _sharedLessonDbContext.Users.AnyAsync(u =>
            u.Email == requestUserDto.Email);

        if (userExists)
        {
            return BadRequest(new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "User already exists"
                }
            });
        }

    
        var user = new User
        {
            Email = requestUserDto.Email,
            Password = requestUserDto.Password
        };

        await _sharedLessonDbContext.Users.AddAsync(user);
        await _sharedLessonDbContext.SaveChangesAsync(CancellationToken.None);

        var token = JwtHelper.CreateToken(user, _configuration);

        
        return Ok(new AuthResult
        {
            Result = true,
            Token = token
        });
    }
}
        return Ok(new AuthResult
        {
            Result = true,
            Token = token
        });
    }
}