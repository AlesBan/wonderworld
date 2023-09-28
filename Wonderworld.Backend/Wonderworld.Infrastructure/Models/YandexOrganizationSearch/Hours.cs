using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Hours
{
    [JsonProperty("text")] public string Text { get; set; }
    [JsonProperty("Availabilities")] public Availability[] Availabilities { get; set; }
}