using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupCreateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("channels",NullValueHandling = NullValueHandling.Ignore)]
        public string Channels { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("handle",NullValueHandling = NullValueHandling.Ignore)]
        public string Handle { get; set; }

        [JsonProperty("include_count",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeCount { get; set; }
    }
}