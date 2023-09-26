using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Feature
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("geometry")] public Geometry Geometry { get; set; }

    [JsonProperty("properties")] public FeatureProperties Properties { get; set; }
}