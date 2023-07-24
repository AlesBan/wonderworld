using Wonderworld.Domain.Entities.Location;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Job;

public class Establishment
{
    public Guid EstablishmentId { get; set; }
    
    public string Type { get; set; }
    public string Title { get; set; }

    public Guid CityId { get; set; }
    public City City { get; set; }
    
    public ICollection<User> Users { get; set; }

}