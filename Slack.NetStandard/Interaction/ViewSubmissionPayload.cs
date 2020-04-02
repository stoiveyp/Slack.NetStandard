using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class ViewSubmissionPayload : InteractionPayload
    {
        [JsonProperty("view")]
        public View View { get; set; }
    }
}