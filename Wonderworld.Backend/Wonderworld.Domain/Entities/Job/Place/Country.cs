namespace Wonderworld.Domain.Entities.Job;

public class Country
{
    public Guid CountryId { get; set; }
    public string Title { get; set; }
    
    public ICollection<City> Cities { get; set; }
}