using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowExecutionResultPayload
{
    [JsonProperty("workflow_name")]
    public string WorkflowName { get; set; }

    [JsonProperty("exec_outcome",NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExecOutcome ExecOutcome { get; set; }
}