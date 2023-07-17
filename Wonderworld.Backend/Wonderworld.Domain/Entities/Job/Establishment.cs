namespace Wonderworld.Domain.Entities;

public class Establishment
{
    public Guid EstablishmentId { get; set; }
    
    public string Type { get; set; }
    public string FullTitle { get; set; }

    public Guid CityId { get; set; }
}