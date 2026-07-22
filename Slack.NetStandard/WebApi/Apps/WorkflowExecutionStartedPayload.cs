using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowExecutionStartedPayload
{
    [JsonProperty("workflow_name")]
    public string WorkflowName { get; set; }

    [JsonProperty("actor")]
    public string Actor { get; set; }
}