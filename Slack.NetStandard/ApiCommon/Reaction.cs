using Newtonsoft.Json;

namespace Slack.NetStandard.ApiCommon
{
    public class Reaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("users"), AcceptedArray]
        public string[] Users { get; set; }
    }
}