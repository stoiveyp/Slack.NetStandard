using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.View
{
    internal class UpdateViewRequest
    {
        [JsonProperty("view")]
        public Objects.View View { get; set; }

        [JsonProperty("external_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }

        [JsonProperty("view_id",NullValueHandling = NullValueHandling.Ignore)]
        public string ViewId { get; set; }

        [JsonProperty("hash",NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
}