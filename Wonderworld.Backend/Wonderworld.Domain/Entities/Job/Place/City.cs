namespace Wonderworld.Domain.Entities.Job;

public class City
{
    public Guid CityId { get; set; }
    public string Title { get; set; }
    
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    
    public List<Establishment> Establishments { get; set; }
}