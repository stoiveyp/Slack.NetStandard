using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Teams
{
    public class TeamIntegrationLogResponse : WebApiResponse
    {
        [JsonProperty("logs",NullValueHandling = NullValueHandling.Ignore)]
        public IntegrationLog[] Logs { get; set; }

        [JsonProperty("paging",NullValueHandling = NullValueHandling.Ignore)]
        public Paging Paging { get; set; }
    }
}