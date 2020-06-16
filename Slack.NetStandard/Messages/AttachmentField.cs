using Newtonsoft.Json;

namespace Slack.NetStandard.Messages
{
    public class AttachmentField
    {
        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("value",NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("short",NullValueHandling = NullValueHandling.Ignore)]
        public bool? Short { get; set; }
    }
}