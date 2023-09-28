using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Interval
{
    [JsonProperty("from")] public string From { get; set; }

    [JsonProperty("to")] public string To { get; set; }
}