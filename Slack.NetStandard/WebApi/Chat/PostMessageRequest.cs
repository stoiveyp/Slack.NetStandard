using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostMessageRequest : MessageRequestBase
    {
        [JsonProperty("mrkdwn",NullValueHandling = NullValueHandling.Ignore)]
        public bool UseMarkdown { get; set; }

        [JsonProperty("reply_broadcast", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReplyBroadcast { get; set; }

        [JsonProperty("unfurl_links", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UnfurlLinks { get; set; }

        [JsonProperty("unfurl_media", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UnfurlMedia { get; set; }
    }
}