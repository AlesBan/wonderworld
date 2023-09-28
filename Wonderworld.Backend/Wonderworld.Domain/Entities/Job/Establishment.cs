using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;
using Wonderworld.Domain.EntityConnections;

namespace Wonderworld.Domain.Entities.Job;

public class Establishment
{
    public Guid EstablishmentId { get; set; }
    public string Title { get; set; }= string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<EstablishmentTypeEstablishment> EstablishmentTypes { get; set; } = new List<EstablishmentTypeEstablishment>();

}