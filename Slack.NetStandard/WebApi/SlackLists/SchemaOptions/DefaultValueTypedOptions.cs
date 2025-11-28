using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.SlackLists
{
    public class DefaultValueTypedOptions
    {
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }

        [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
        public string Select { get; set; }
    }
}