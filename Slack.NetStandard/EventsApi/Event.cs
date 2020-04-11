using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.EventsApi
{
    [JsonConverter(typeof(EventConverter))]
    public class Event
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
