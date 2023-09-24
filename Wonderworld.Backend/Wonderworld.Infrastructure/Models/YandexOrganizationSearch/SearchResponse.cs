namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class SearchResponse
{
    public int found { get; set; }
    public Point Point { get; set; }
    public List<List<double>> boundedBy { get; set; }
    public string display { get; set; }
}