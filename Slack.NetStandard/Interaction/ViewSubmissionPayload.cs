using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class ViewSubmissionPayload : InteractionPayload
    {
        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }

        [JsonProperty("response_url",NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl{ get; set; }
    }
}