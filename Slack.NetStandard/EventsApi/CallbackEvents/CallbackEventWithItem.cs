using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class CallbackEventWithItem : CallbackEvent
    {
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }
    }
}