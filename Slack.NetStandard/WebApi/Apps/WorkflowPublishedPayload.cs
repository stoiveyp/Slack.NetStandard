using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowPublishedPayload
{
    [JsonProperty("workflow_name")]
    public string WorkflowName { get; set; }
}