using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowReference
    {
        [JsonProperty("version_id")]
        public string VersionId { get; set; }

        [JsonProperty("app_steps")]
        public WorkflowStepReference[] AppSteps { get; set; }
    }
}