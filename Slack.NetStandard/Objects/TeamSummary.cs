using Newtonsoft.Json;

namespace Slack.NetStandard.Objects
{
    public class TeamSummary
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }
    }
}