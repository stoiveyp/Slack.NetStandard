using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    [JsonConverter(typeof(CallbackEventConverter))]
    public interface ICallbackEvent
    {
        [JsonProperty("type")]
        string Type { get; set; }

        [JsonProperty("event_ts", NullValueHandling = NullValueHandling.Ignore)]
        Timestamp EventTimestamp { get; set; }
    }
}