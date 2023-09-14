using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowPublished : CallbackEvent
    {
        public const string EventType = "workflow_published";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_published_configuration")]
        public WorkflowReference WorkflowPublishedConfiguration { get; set; }
    }
}