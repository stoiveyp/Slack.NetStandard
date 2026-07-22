using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Admin
{
    internal class AdminAppDecision
    {
        [JsonProperty("app_id",NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("request_id",NullValueHandling = NullValueHandling.Ignore)]
        public string RequestId { get; set; }

        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }

        [JsonProperty("enterprise_id",NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }
    }
}
