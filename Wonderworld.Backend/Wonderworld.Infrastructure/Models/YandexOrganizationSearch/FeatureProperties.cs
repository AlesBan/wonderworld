using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class FeatureProperties
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("boundedBy")] public double[][] BoundedBy { get; set; }

    [JsonProperty("uri")] public string Uri { get; set; }

    [JsonProperty("CompanyMetaData")] public CompanyMetaData CompanyMetaData { get; set; }
}