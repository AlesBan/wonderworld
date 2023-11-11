using MediatR;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Application.Dtos.UserDtos.AuthenticationDtos;
using Wonderworld.Application.Dtos.UserDtos.CreateAccountDtos;

namespace Wonderworld.Infrastructure.Services.AccountServices;

public interface IUserAccountService
{
    public Task<UserProfileDto> GetUserProfile(Guid userId, IMediator mediator);
    public Task<IEnumerable<UserProfileDto>> GetAllUsers(IMediator mediator);
    public Task<string> RegisterUser(UserRegisterRequestDto requestUserDto, IMediator mediator);
    public Task<string> LoginUser(UserLoginRequestDto requestUserDto, IMediator mediator);
    public Task<string> ConfirmEmail(Guid userId, string token, IMediator mediator);
    public Task<string> ForgotPassword(string userEmail, IMediator mediator);
    public Task<UserProfileDto> CreateUserAccount(Guid userId, CreateUserAccountRequestDto requestUserDto, IMediator mediator);
    public Task DeleteUser(Guid userId, IMediator mediator);
    public Task DeleteAllUsers(IMediator mediator);
    
    
}