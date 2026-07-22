using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class ExternalRef
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id{ get; set; }
    }
}