using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.Workflows;

[JsonConverter(typeof(StepInputConverter))]
public class StepInput
{
    [JsonProperty("hidden",NullValueHandling = NullValueHandling.Ignore)]
    public bool? Hidden { get; set; }

    [JsonProperty("locked",NullValueHandling = NullValueHandling.Ignore)]
    public bool? Locked { get; set; }
}