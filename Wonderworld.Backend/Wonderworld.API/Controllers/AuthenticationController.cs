using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Models.AuthDtoModels;
using Wonderworld.API.Models.AuthModels;
using Wonderworld.API.Services.Auth;
using Wonderworld.Application.Interfaces;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
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
        if (!ModelState.IsValid)
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

        var token = AuthService.CreateToken(existingUser, _configuration);
        return Ok(new AuthResult()
        {
            Result = true,
            Token = token
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto requestUserDto)
    {
        if (!ModelState.IsValid)
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

        return Ok(new AuthResult
        {
            Result = true,
            Token = AuthService.CreateToken(user, _configuration),
        });
    }
}