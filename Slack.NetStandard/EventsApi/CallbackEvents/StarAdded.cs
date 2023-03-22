using Newtonsoft.Json;
using Slack.NetStandard.Objects;
using Slack.NetStandard.Objects.Stars;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class StarAdded : CallbackEvent
    {
        public const string EventType = "star_added";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public StarredItem Item { get; set; }
    }
}