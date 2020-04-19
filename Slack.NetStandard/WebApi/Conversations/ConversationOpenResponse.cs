using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class ConversationOpenResponse:WebApiResponse
    {
        [JsonProperty("no_op",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Noop { get; set; }

        [JsonProperty("already_open",NullValueHandling = NullValueHandling.Ignore)]
        public bool? AlreadyOpen { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }
    }
}