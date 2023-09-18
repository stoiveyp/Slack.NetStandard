using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using System;

namespace Slack.NetStandard.Interaction
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowStepEditPayload : InteractionPayload
    {
        [JsonProperty("workflow_step",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowStep WorkflowStep { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }
    }
}