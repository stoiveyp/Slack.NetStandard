using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class Filter
    {
        [JsonProperty("include",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Include { get; set; }

        [JsonProperty("exclude_bot_users",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeBotUsers { get; set; }

        [JsonProperty("exclude_external_shared_channels",NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeExternalSharedChannels { get; set; }

    }
}