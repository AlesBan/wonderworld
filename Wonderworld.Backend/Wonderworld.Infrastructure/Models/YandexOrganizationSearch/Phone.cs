using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Phone
{
    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("formatted")] public string Formatted { get; set; }
}