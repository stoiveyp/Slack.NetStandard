using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamFilter : TeamRequestFilter
    {
        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string Enterprise { get; set; }
    }
}