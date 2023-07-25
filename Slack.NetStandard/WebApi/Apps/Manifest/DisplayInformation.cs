using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps.Manifest;

public class DisplayInformation
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("long_description",NullValueHandling = NullValueHandling.Ignore)]
    public string LongDescription { get; set; }

    [JsonProperty("background_color",NullValueHandling = NullValueHandling.Ignore)]
    public string BackgroundColor { get; set; }

    [JsonExtensionData]
    public Dictionary<string,object> OtherFields { get; set; }
}