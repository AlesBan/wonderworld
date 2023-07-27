using MediatR;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Location;

namespace Wonderworld.Application.Handlers.UserHandlers.Commands.UpdateUserDescription;

public class UpdateUserDescriptionCommand : IRequest
{
    public Guid UserId { get; set; }
    public string Description { get; set; } = string.Empty;

}