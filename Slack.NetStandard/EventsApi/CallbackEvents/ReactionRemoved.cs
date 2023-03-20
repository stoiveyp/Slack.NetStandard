using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class ReactionRemoved : CallbackEventWithItem
    {
        public const string EventType = "reaction_removed";

        [JsonProperty("reaction", NullValueHandling = NullValueHandling.Ignore)]
        public string Reaction { get; set; }

        [JsonProperty("item_user", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemUser { get; set; }
    }
}