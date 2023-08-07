using MediatR;
using Wonderworld.Application.Dtos;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Queries.GetProfileUser;

public class GetProfileUserCommand : IRequest<UserProfileDto>
{
    public User User { get; set; }
}