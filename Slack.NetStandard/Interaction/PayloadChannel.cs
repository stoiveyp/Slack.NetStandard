using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class PayloadChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}