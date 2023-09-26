using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Category
{
    [JsonProperty("class")] public string Class { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
}