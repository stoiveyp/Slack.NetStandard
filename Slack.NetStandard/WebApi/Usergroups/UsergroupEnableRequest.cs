using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupEnableRequest
    {
        [JsonProperty("usergroup")]
        public string Usergroup { get; set; }

        [JsonProperty("include_count",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeCount { get; set; }
        
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}