using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostEphemeralMessageRequest : MessageRequestBase
    {
        [JsonProperty("user")]
        public string User { get; set; }
    }
}