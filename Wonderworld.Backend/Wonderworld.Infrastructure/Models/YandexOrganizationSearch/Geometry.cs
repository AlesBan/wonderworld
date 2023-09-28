namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

using Newtonsoft.Json;

public class Geometry
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("coordinates")] public double[] Coordinates { get; set; }
}