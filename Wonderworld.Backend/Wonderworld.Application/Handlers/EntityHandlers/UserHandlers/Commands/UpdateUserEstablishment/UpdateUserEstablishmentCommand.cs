using MediatR;
using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Application.Handlers.EntityHandlers.UserHandlers.Commands.UpdateUserEstablishment;

public class UpdateUserEstablishmentCommand : IRequest
{
    public User User { get; set; }
    public Institution Establishment { get; set; }
}