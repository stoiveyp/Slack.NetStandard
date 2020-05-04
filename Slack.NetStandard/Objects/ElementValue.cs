using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class ElementValue
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}