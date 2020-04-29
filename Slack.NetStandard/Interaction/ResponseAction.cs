using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Interaction
{
    [JsonConverter(typeof(ResponseActionConverter))]
    public abstract class ResponseAction
    {
        [JsonProperty("response_action")]
        public abstract string Type { get; }
    }
}
