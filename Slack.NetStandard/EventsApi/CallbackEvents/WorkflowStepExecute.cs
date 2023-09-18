using System;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowStepExecute:CallbackEvent
    {
        public const string EventType = "workflow_step_execute";

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }

        [JsonProperty("workflow_step",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowStepInformation WorkflowStep { get; set; }
    }
}
