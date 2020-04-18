using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Conversations
{
    public class CreateConversationResponse:WebApiResponse
    {
        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }
    }
}
