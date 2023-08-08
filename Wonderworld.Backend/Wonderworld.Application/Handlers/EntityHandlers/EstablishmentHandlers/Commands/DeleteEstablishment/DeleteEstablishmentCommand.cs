using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.EstablishmentHandlers.Commands.DeleteEstablishment;

public class DeleteEstablishmentCommand : IRequest
{
    public Guid EstablishmentId { get; set; }
}