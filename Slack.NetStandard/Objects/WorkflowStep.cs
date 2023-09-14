using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace Slack.NetStandard.Objects
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowStep
    {
        [JsonProperty("workflow_step_edit_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepEditId { get; set; }

        [JsonProperty("workflow_step_execute_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepExecuteId { get; set; }

        [JsonProperty("workflow_instance_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowInstanceId { get; set; }

        [JsonProperty("workflow_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }

        [JsonProperty("step_id",NullValueHandling = NullValueHandling.Ignore)]
        public string StepId { get; set; }

        [JsonProperty("step_name",NullValueHandling = NullValueHandling.Ignore)]
        public string StepName { get; set; }

        [JsonProperty("step_image_url",NullValueHandling = NullValueHandling.Ignore)]
        public string StepImageUrl { get; set; }

        [JsonProperty("inputs",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, WorkflowInput> Inputs { get; set; }

        [JsonProperty("outputs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<WorkflowOutput> Outputs { get; set; } = new List<WorkflowOutput>();

        public bool ShouldSerializeOutputs() => Outputs?.Any() ?? false;
    }
}
