using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wonderworld.Application.Dtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.CreateAccountDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.API.Services.AccountServices;

public interface IUserAccountService
{
    public Task<IActionResult> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> CreateUserAccount(Guid userId, UserCreateAccountRequestDto requestUserDto, IMediator mediator);
    public Task<IActionResult> DeleteUser(Guid userId, IMediator mediator);
}