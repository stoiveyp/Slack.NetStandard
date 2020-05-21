using Newtonsoft.Json;

namespace Slack.NetStandard.Interaction
{
    public class ErrorInformation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}