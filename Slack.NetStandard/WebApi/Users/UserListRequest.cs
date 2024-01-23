using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Users
{
    public class UserListRequest
    {
        [JsonProperty("cursor",NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; set; }
        
        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        
        [JsonProperty("include_locale",NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeLocale { get; set; }
                
        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}