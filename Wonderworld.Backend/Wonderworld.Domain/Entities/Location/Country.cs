namespace Wonderworld.Domain.Entities.Location;

public class Country
{
    public Guid CountryId { get; set; }
    public string Title { get; set; }
    public ICollection<City> Cities { get; set; }
}