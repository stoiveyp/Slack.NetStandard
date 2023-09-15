using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class StringArrayStepInput : StepInput
{
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Value { get; set; } = new();

    public bool ShouldSerializeValue() => Value?.Any() ?? false;
}