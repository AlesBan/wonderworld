using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Application.Dtos.ProfileDtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetProfileUser;

public class GetUserProfileCommand : IRequest<UserProfileDto>
{
    public User User { get; set; }
}