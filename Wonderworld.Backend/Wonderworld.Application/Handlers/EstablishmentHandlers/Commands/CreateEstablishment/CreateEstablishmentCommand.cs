
namespace Wonderworld.Application.Handlers.EstablishmentHandlers.Commands.CreateEstablishment;

public class CreateEstablishmentCommand
{
    public Guid EstablishmentId { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
}