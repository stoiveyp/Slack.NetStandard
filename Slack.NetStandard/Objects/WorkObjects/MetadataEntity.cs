using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class MetadataEntity
    {
        public MetadataEntity() { }
        public MetadataEntity(string entityType)
        {
            EntityType = entityType;
        }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("app_unfurl_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AppUnfurlUrl { get; set; }

        [JsonProperty("external_ref", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalRef ExternalRef { get; set; }

        [JsonProperty("entity_payload", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayload EntityPayload { get; set; }

        //https://docs.slack.dev/messaging/work-objects/#editing-field-mapping
    }
}