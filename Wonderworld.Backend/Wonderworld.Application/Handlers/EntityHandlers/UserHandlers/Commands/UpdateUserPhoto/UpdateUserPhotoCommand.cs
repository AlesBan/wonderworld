using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserPhoto;

public class UpdateUserPhotoCommand : IRequest
{
    public User User { get; set; }
    public string NewPhotoUrl { get; set; }
}