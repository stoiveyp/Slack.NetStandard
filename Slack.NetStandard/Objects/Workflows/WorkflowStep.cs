using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Workflows;

public class WorkflowStep
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("function_id",NullValueHandling = NullValueHandling.Ignore)]
    public string FunctionId { get; set; }

    [JsonProperty("inputs", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, StepInput> Inputs { get; set; } = new();

    [JsonProperty("is_pristine",NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsPristine { get; set; }

    public bool ShouldSerializeInputs() => Inputs?.Any() ?? false;
}