using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Functions;

public class ExportResponseWorkflowStepRequest
{
    public ExportResponseWorkflowStepRequest(){}

    public ExportResponseWorkflowStepRequest(string stepId)
    {
        StepId = stepId;
    }

    [JsonProperty("step_id")]
    public string StepId { get; set; }

    [JsonProperty("workflow",NullValueHandling = NullValueHandling.Ignore)]
    public string Workflow { get; set; }

    [JsonProperty("workflow_app_id",NullValueHandling = NullValueHandling.Ignore)]
    public string WorkflowAppId { get; set; }

    [JsonProperty("workflow_id",NullValueHandling = NullValueHandling.Ignore)]
    public string WorkflowId { get; set; }
}