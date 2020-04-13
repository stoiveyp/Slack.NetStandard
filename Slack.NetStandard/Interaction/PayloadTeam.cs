using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class PayloadTeam
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
    }
}