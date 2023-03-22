using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.Stars
{
    public class StarredChannelItem : StarredItem
    {
        [JsonProperty("channel",NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("date_create", NullValueHandling = NullValueHandling.Ignore)]
        public long DateCreated { get; set; }
    }
}