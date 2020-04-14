using Newtonsoft.Json;

namespace Slack.NetStandard.EventsApi.CallbackEvents
{
    public class Scope
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("is_sensitive", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSensitive { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}