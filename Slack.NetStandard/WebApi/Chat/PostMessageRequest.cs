using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Chat
{
    public class PostMessageRequest : Message {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("as_user")]
        public bool AsUser { get; set; }

        //Attachments

        [JsonProperty("icon_emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string IconEmoji { get; set; }

        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("link_names",NullValueHandling = NullValueHandling.Ignore)]
        public bool? LinkNames { get; set; }

        [JsonProperty("parse",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageParsing MessageParsing { get; set; }

        [JsonProperty("reply_broadcast",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReplyBroadcast { get; set; }

        [JsonProperty("unfurl_links",NullValueHandling = NullValueHandling.Ignore)]
        public bool? UnfurlLinks { get; set; }

        [JsonProperty("unfurl_media", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UnfurlMedia { get; set; }

        [JsonProperty("username",NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }


    }
}