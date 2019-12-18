using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi
{
    public class ResponseMessage:Message
    {
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("bot_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BotId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtype",NullValueHandling = NullValueHandling.Ignore)]
        public string SubType { get; set; }
    }
}
