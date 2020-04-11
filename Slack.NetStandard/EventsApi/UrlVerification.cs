using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi
{
    public class UrlVerification:Event
    {
        public const string EventType = "url_verification";

        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}