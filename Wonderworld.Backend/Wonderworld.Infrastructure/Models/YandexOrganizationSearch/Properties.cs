namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Properties
{
    public ResponseMetaData ResponseMetaData { get; set; }
    public GeocoderMetaData GeocoderMetaData { get; set; }
    public string description { get; set; }
    public string name { get; set; }
    public List<List<double>> boundedBy { get; set; }
}