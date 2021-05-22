using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class ViewSubmissionPayload : InteractionPayload
    {
        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("response_urls",NullValueHandling = NullValueHandling.Ignore)]
        public string[] ResponseUrls{ get; set; }

        [JsonProperty("workflow_step",NullValueHandling = NullValueHandling.Ignore)]
        public WorkflowStep WorkflowStep { get; set; }

        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
}