using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.WebApi.Teams
{
    public class InfoResponse : WebApiResponse
    {
        [JsonProperty("team",NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }
    }
}