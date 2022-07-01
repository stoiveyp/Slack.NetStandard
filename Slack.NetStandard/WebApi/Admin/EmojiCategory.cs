using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class EmojiCategory
    {
        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("emoji_names", NullValueHandling = NullValueHandling.Ignore),AcceptedArray]
        public string[] EmojiNames { get; set; }
    }
}