using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class SearchRequest
{
    [JsonProperty("request")] public string Request { get; set; }

    [JsonProperty("skip")] public long Skip { get; set; }

    [JsonProperty("results")] public long Results { get; set; }

    [JsonProperty("boundedBy")] public double[][] BoundedBy { get; set; }
}