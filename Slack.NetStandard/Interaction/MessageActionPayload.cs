using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.WebApi;

namespace Slack.NetStandard.Interaction
{
    public class MessageActionPayload : ShortcutPayload
    {
        [JsonProperty("response_url")]
        public string ResponseUrl { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}