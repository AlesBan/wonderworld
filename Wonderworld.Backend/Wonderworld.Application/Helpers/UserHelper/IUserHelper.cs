using MediatR;
using Wonderworld.Application.Dtos.UserDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Helpers.UserHelper;

public interface IUserHelper
{
    public Task<User> GetUserById(Guid userId, IMediator mediator);
    public Task<User> GetUserByEmail(string email, IMediator mediator);
    public Task<Guid> GetUserIdByClassId(Guid classId, IMediator mediator);
    public void CheckUserVerification(User user);
    public Task<UserProfileDto> MapUserToUserProfileDto(User user);
    public string GenerateVerificationCode();
    public void CheckResetTokenExpiration(User user);
    public string GeneratePasswordResetCode();
    public void CheckResetPasswordCode(User user, string code);
}