using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wonderworld.API.Services.AccountServices;
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

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromBody] UserCreateAccountRequestDto requestUserDto)
    {
        var jwtToken = HttpContext.Request
            .Headers["Authorization"]
            .ToString();
        var jwtHandler = new JwtSecurityTokenHandler();
        var decodedToken = jwtHandler.ReadJwtToken(jwtToken.Split(' ')[1]);

        var nameIdentifier = decodedToken.Claims
            .FirstOrDefault(claim =>
                claim.Type == ClaimTypes.NameIdentifier)?
            .Value;
        
        if (nameIdentifier == null)
        {
            return Ok();
        }

        var userId = Guid.Parse(nameIdentifier);
        await _userAccountService.CreateUserAccount(userId, requestUserDto, Mediator);

        return Ok();
    }
}