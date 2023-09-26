using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class SearchResponse
{
    [JsonProperty("found")] public long Found { get; set; }
    [JsonProperty("display")] public string Display { get; set; }
    [JsonProperty("boundedBy")] public double[][] BoundedBy { get; set; }
}