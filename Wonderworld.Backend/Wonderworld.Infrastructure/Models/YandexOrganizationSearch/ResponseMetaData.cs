using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class ResponseMetaData
{
    [JsonProperty("SearchResponse")] public SearchResponse SearchResponse { get; set; }

    [JsonProperty("SearchRequest")] public SearchRequest SearchRequest { get; set; }
    
}