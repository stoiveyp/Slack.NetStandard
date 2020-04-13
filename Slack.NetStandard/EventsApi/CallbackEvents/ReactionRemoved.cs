using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ReactionRemoved : CallbackEvent
    {
        public const string EventType = "reaction_removed";

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("reaction", NullValueHandling = NullValueHandling.Ignore)]
        public string Reaction { get; set; }

        [JsonProperty("item_user", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemUser { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }

        [JsonProperty("event_ts")]
        public Timestamp EventTimestamp { get; set; }
    }
}