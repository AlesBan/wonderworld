using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;

namespace Wonderworld.API.Services.AccountServices;

public interface IUserAccountService
{
    public Task<IActionResult> GetUserProfile(Guid userId, IMediator mediator);
    public Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> CreateUserAccount(Guid userId, CreateUserAccountRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> DeleteUser(Guid userId, IMediator mediator);
}