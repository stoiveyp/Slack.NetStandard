using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi
{
    public class MessageItem
    {
        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }

        [JsonProperty("created",NullValueHandling = NullValueHandling.Ignore)]
        public long Created { get; set; }

        [JsonProperty("created_by",NullValueHandling = NullValueHandling.Ignore)]
        public string Createdby { get; set; }

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
}