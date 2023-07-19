using Wonderworld.Domain.Entities.Job;
using Wonderworld.Domain.Entities.Main;

namespace Wonderworld.Domain.Entities.Location;

public class City
{
    public Guid CityId { get; set; }
    public string Title { get; set; }
    
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Establishment> Establishments { get; set; }
}