using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.NetStandard.Objects
{
    [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
    public class WorkflowOutput
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public WorkflowOutputType Type { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("label",NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
    }
}
