using Wonderworld.Domain.Entities.Job;

namespace Wonderworld.Domain.EntityConnections;

public class EstablishmentTypeEstablishment
{
    public Guid EstablishmentTypeId { get; set; }
    public EstablishmentType EstablishmentType { get; set; }
    
    public Guid EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }
}
