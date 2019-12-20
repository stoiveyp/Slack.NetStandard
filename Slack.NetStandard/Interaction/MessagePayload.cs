using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class MessagePayload : InteractionPayload
    {
        [JsonProperty("message")]
        public ResponseMessage Message { get; set; }

        [JsonProperty("container")]
        public MessageContainer Container { get; set; }

        [JsonProperty("response_url",NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseUrl { get; set; }
    }
}