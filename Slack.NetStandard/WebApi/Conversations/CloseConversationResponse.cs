using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class CloseConversationResponse:WebApiResponse
    {
        [JsonProperty("no_op",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Noop { get; set; }

        [JsonProperty("already_closed",NullValueHandling = NullValueHandling.Ignore)]
        public bool? AlreadyClosed { get; set; }
    }
}
