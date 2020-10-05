using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class WorkflowInput
    {
        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        [JsonProperty("skip_variable_replacement", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipVariableReplacement { get; set; }

        [JsonProperty("variables",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Variables { get; set; }
    }
}
