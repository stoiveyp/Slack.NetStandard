﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowStepInformation
    {
        [JsonProperty("step_id",NullValueHandling = NullValueHandling.Ignore)]
        public string StepId { get; set; }

        [JsonProperty("workflow_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }

        [JsonProperty("workflow_instance_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowInstanceId { get; set; }

        [JsonProperty("workflow_step_execute_id",NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepExecuteId { get; set; }

        [JsonProperty("inputs",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,WorkflowValue> Inputs { get; set; }

        [JsonProperty("outputs",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowOutput[] Outputs { get; set; }
    }
}