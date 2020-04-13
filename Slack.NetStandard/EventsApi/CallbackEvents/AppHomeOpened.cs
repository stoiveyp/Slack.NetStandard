using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class AppHomeOpened:CallbackEvent
    {
        public const string EventType = "app_home_opened";
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("tab", NullValueHandling = NullValueHandling.Ignore)]
        public string Tab { get; set; }

        [JsonProperty("view", NullValueHandling = NullValueHandling.Ignore)]
        public View View { get; set; }
    }
}
