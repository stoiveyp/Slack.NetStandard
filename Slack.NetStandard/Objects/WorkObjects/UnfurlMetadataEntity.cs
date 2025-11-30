using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{

    public abstract class UnfurlMetadataEntity<T> where T : EntityPayloadField
    {
        [JsonProperty("entity_payload", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayload<T> EntityPayload { get; set; }
    }

    public abstract class UnfurlMetadataEntity
    {
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("app_unfurl_url")]
        public string AppUnfurlUrl { get; set; }

        [JsonProperty("external_ref")]
        public ExternalRef ExternalRef { get; set; }

        //https://docs.slack.dev/messaging/work-objects/#editing-field-mapping
    }
}