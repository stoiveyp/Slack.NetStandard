using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowUnpublished : CallbackEvent
    {
        public const string EventType = "workflow_unpublished";

        [JsonProperty("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_draft_configuration")]
        public WorkflowReference WorkflowDraftConfiguration { get; set; }
    }
}