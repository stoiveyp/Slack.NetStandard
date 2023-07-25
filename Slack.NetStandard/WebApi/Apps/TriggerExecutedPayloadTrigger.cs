using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Apps;

public class TriggerExecutedPayloadTrigger
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object> Config { get; set; }

    [JsonProperty("trip_information",NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object> TripInformation { get; set; }

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public TriggerExecutedType Type { get; set; }
}