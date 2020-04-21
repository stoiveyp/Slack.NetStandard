using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Reaction
{
    public class ReactionGetResponse:WebApiResponse
    {
        [JsonProperty("file",NullValueHandling = NullValueHandling.Ignore)]
        public File File { get; set; }

        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
    }
}
