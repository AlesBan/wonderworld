using Newtonsoft.Json;

namespace Wonderworld.Infrastructure.Models.YandexOrganizationSearch;

public class Availability
{
    [JsonProperty("Intervals", NullValueHandling = NullValueHandling.Ignore)]
    public Interval[] Intervals { get; set; }

    [JsonProperty("Monday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Monday { get; set; }

    [JsonProperty("Tuesday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Tuesday { get; set; }

    [JsonProperty("Wednesday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Wednesday { get; set; }

    [JsonProperty("Thursday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Thursday { get; set; }

    [JsonProperty("Friday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Friday { get; set; }

    [JsonProperty("Saturday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Saturday { get; set; }

    [JsonProperty("TwentyFourHours", NullValueHandling = NullValueHandling.Ignore)]
    public bool? TwentyFourHours { get; set; }

    [JsonProperty("Everyday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Everyday { get; set; }

    [JsonProperty("Sunday", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Sunday { get; set; }
}