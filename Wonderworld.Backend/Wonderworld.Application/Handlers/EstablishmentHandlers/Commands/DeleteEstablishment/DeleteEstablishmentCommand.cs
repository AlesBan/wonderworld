using MediatR;

namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.DeleteEstablishment;

public class DeleteEstablishmentCommand : IRequest
{
    public Guid EstablishmentId { get; set; }
}