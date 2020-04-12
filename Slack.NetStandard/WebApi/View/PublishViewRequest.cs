using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.View
{
    internal class PublishViewRequest
    {
        [JsonProperty("user_id")]
        public string User { get; set; }

        [JsonProperty("view")]
        public Objects.View View { get; set; }

        [JsonProperty("hash",NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
}