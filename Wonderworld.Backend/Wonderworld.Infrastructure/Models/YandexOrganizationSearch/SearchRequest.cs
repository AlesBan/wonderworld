namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class SearchRequest
{
    public string request { get; set; }
    public int results { get; set; }
    public int skip { get; set; }
    public List<List<double>> boundedBy { get; set; }
}