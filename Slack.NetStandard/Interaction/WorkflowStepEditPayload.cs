using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Interaction
{
    public class WorkflowStepEditPayload : InteractionPayload
    {
        [JsonProperty("workflow_step",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowStep WorkflowStep { get; set; }

        [JsonProperty("callback_id",NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackId { get; set; }
    }
}