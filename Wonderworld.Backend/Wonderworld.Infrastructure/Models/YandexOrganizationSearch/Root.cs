using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Root
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("properties")] public Properties Properties { get; set; }
    [JsonProperty("features")] public Feature[] Features { get; set; }
}