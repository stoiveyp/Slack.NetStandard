using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi;
using System;

namespace Slack.NetStandard.Interaction
{
    public class ViewSubmissionPayload : InteractionPayload
    {
        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("response_urls",NullValueHandling = NullValueHandling.Ignore), AcceptedArray]
        public string[] ResponseUrls{ get; set; }

        [JsonProperty("workflow_step",NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("Steps from apps are now deprecated. For more information see https://api.slack.com/changelog/2023-08-workflow-steps-from-apps-step-back")]
        public WorkflowStep WorkflowStep { get; set; }

        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
}