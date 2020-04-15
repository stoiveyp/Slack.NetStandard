using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    public class TeamCreateResponse : WebApiResponse
    {
        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public string Team { get; set; }
    }
}