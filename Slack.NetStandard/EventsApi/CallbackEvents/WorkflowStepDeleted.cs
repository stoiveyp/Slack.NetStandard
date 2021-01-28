using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowStepDeleted : CallbackEvent
    {
        public const string EventType = "workflow_step_deleted";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public WorkflowReference WorkflowDraftConfiguration { get; set; }

        [JsonProperty("workflow_published_configuration")]
        public WorkflowReference WorkflowPublishedConfiguration { get; set; }
    }
}