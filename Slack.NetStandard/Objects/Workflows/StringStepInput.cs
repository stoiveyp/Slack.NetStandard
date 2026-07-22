using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class StringStepInput : StepInput
{
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }
}