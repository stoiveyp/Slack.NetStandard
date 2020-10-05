using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflow
{
    internal class StepFailedRequest
    {
        [JsonProperty("workflow_step_execute_id")]
        public string WorkflowStepExecuteId { get; set; }

        [JsonProperty("error",NullValueHandling = NullValueHandling.Ignore)]
        public Error Error { get; set; }
    }
}