using Newtonsoft.Json;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.EventsApi
{
    public class EventCallback: EventCallbackBase
    {
        [JsonProperty("event",NullValueHandling = NullValueHandling.Ignore)]
        public ICallbackEvent Event { get; set; }
    }

    public class EventCallback<T> : EventCallbackBase where T:ICallbackEvent
    {
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public T Event { get; set; }
    }
}
