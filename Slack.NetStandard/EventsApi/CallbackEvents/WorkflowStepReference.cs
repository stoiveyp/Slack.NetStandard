using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
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