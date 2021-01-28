using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowDeleted : CallbackEvent
    {
        public const string EventType = "workflow_deleted";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public WorkflowReference WorkflowDraftConfiguration { get; set; }
    }
}