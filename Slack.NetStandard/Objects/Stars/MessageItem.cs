using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.Objects.Stars
{
    public class MessageItem : StarredItem
    {
        public const string ItemType = "message";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("date_create", NullValueHandling = NullValueHandling.Ignore)]
        public long DateCreated { get; set; }

        [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
    }
}