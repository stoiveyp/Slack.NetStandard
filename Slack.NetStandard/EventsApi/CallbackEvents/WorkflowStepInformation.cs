using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class WorkflowStepInformation
    {
        [JsonProperty("workflow_step_execute_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepExecuteId { get; set; }

        [JsonProperty("inputs",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,WorkflowValue> Inputs { get; set; }

        [JsonProperty("outputs",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowOutput[] Outputs { get; set; }
    }
}