using Newtonsoft.Json;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class InteractiveMessagePayload : InteractiveComponentPayload
    {
        [JsonProperty("message")]
        public ResponseMessage Message { get; set; }

        [JsonProperty("container")]
        public MessageContainer Container { get; set; }
    }
}