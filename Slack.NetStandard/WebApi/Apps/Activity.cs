using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.WebApi.Apps;

public class Activity<T>:Activity
{
    [JsonProperty("payload")]
    public T Payload { get; set; }
}

[JsonConverter(typeof(ActivityConverter))]
public class Activity
{
    [JsonProperty("level")]
    [JsonConverter(typeof(StringEnumConverter))]
    public LogLevel Level { get; set; }

    [JsonProperty("event_type")]
    public string EventType { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("component_type")]
    public string ComponentType { get; set; }

    [JsonProperty("component_id")]
    public string ComponentId { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("trace_id")]
    public string TraceId { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> OtherFields { get; set; }
}