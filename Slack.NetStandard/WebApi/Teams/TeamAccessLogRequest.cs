using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamAccessLogRequest
    {
        [JsonProperty("before",NullValueHandling = NullValueHandling.Ignore)]
        public long? Before { get; set; }
        
        [JsonProperty("count",NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }
        
        [JsonProperty("page",NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
                
        [JsonProperty("team_id",NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
    }
}