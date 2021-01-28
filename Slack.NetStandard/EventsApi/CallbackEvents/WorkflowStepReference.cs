using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowStepReference
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("workflow_step_id")]
        public string WorkflowStepId { get; set; }

        [JsonProperty("callback_id")]
        public string CallbackId { get; set; }
    }
}