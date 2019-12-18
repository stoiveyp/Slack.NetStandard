using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class EphemeralResponse:WebApiResponse
    {
        [JsonProperty("message_ts")]
        public string Timestamp { get; set; }
    }
}
