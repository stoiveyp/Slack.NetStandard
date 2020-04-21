using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class ChannelValue
    {
        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("creator",NullValueHandling = NullValueHandling.Ignore)]
        public string Creator { get; set; }
        
        [JsonProperty("last_set",NullValueHandling = NullValueHandling.Ignore)]
        public long LastSet { get; set; }
    }
}