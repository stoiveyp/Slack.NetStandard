using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Usergroups
{
    public class UsergroupListRequest
    {
        [JsonProperty("include_count", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeCount { get; set; }
        
        [JsonProperty("include_disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeDisabled { get; set; }

        [JsonProperty("include_users", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeUsers { get; set; }
        
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}