using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Stars
{
    public class ChannelItem : StarredItem
    {
        public const string ItemType = "channel";

        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
}