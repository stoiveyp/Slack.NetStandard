using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Elements.RichText
{
    public class ChannelElement : StyledRichTextElement
    {
        public const string ElementName = "channel";

        [JsonProperty("channel_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ChannelId { get; set; }
    }
}