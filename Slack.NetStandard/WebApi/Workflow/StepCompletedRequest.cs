using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Workflow
{
    internal class StepCompletedRequest
    {
        [JsonProperty("workflow_step_execute_id")]
        public string WorkflowStepExecuteId { get; set; }

        [JsonProperty("outputs",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,object> Outputs { get; set; }
    }
}
