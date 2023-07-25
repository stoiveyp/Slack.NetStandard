using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Apps;

public class WorkflowUnpublishedPayload
{
    [JsonProperty("workflow_name")]
    public string WorkflowName { get; set; }
}