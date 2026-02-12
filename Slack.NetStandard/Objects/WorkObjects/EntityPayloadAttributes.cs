using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadAttributes
    {
        [JsonProperty("title")]
        public EntityPayloadAttributeTitle Title { get; set; }

        [JsonProperty("display_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayId { get; set; }

        [JsonProperty("display_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayType { get; set; }

        [JsonProperty("product_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName { get; set; }

        [JsonProperty("product_icon", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayloadIcon ProductIcon { get; set; }

        [JsonProperty("full_size_preview", NullValueHandling = NullValueHandling.Ignore)]
        public EntityPayloadFullSizePreview FullSizePreview { get; set; }

        [JsonProperty("metadata_last_modified", NullValueHandling = NullValueHandling.Ignore)]
        public long? MetadataLastModified { get; set; }
    }
}