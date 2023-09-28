using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Job;

public class EstablishmentType
{
    public Guid EstablishmentTypeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<EstablishmentTypeEstablishment> EstablishmentTypes { get; set; } 
        = new List<EstablishmentTypeEstablishment>();
}