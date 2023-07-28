using MediatR;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserDescription;

public class UpdateUserDescriptionCommand : IRequest
{
    public User User { get; set; }
    public string Description { get; set; } = string.Empty;

}