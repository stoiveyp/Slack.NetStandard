using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.Pins;

[JsonConverter(typeof(PinnedItemConverter))]
public class PinnedItem
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
    public long Created { get; set; }

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public string CreatedBy { get; set; }

    [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
    public string Channel { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> OtherFields { get; set; }
}