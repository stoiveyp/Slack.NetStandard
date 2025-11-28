using Newtonsoft.Json;
using Slack.NetStandard.Objects.WorkObjects;

namespace Slack.NetStandard.WebApi.Chat
{
    public class UnfurlMetadataEntity
    {
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_unfurl_url")]
        public string AppUnfurlUrl { get; set; }

        [JsonProperty("external_ref")]
        public ExternalRef ExternalRef { get; set; }

        [JsonProperty("entity_payload", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayload EntityPayload { get; set; }
    }
}