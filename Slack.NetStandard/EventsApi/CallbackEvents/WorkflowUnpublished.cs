using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowUnpublished : CallbackEvent
    {
        public const string EventType = "workflow_unpublished";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public WorkflowReference WorkflowDraftConfiguration { get; set; }
    }
}