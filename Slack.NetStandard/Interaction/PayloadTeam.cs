using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class PayloadTeam
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty("enterprise_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseId { get; set; }

        [JsonProperty("enterprise_name", NullValueHandling = NullValueHandling.Ignore)]
        public string EnterpriseName { get; set; }
    }
}