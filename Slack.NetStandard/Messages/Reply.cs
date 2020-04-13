using Newtonsoft.Json;

namespace Slack.NetStandard.Messages
{
    public class Reply
    {
        [JsonProperty("user",NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("ts",NullValueHandling = NullValueHandling.Ignore)]
        public Timestamp Timestamp { get; set; }
    }
}