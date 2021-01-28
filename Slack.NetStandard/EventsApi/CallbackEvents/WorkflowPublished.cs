using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowPublished : CallbackEvent
    {
        public const string EventType = "workflow_published";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_published_configuration")]
        public WorkflowReference WorkflowPublishedConfiguration { get; set; }
    }
}