using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class UsergroupPreferences
    {
        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Channels { get; set; }

        [JsonProperty("groups",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Groups { get; set; }
    }
}