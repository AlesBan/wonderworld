using MediatR;

namespace Wonderworld.Application.Handlers.EntityHandlers.InstitutionHandlers.Commands.DeleteEstablishment;

public class DeleteInstitutionCommand : IRequest
{
    public Guid EstablishmentId { get; set; }
}