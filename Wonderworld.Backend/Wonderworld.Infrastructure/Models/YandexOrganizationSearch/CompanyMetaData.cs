using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class CompanyMetaData
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("address")] public string Address { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public Uri Url { get; set; }

    [JsonProperty("Phones")] public Phone[] Phones { get; set; }

    [JsonProperty("Categories")] public Category[] Categories { get; set; }

    [JsonProperty("Hours", NullValueHandling = NullValueHandling.Ignore)]
    public Hours Hours { get; set; }
}