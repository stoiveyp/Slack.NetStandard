using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.EventsApi
{
    public class EventCallback: EventCallbackBase
    {
        [JsonProperty("event",NullValueHandling = NullValueHandling.Ignore)]
        public CallbackEvent Event { get; set; }
    }

    public class EventCallback<T> : EventCallbackBase where T:CallbackEvent
    {
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public T Event { get; set; }
    }
}
