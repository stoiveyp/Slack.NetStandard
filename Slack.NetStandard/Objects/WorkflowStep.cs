using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
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

        [JsonProperty("outputs",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowOutput[] Outputs { get; set; }
    }
}
