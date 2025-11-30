using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadAttributes
    {
        [JsonProperty("title")]
        public EntityPayloadAttributeTitle Title { get; set; }

        [JsonProperty("display_id")]
        public string DisplayId { get; set; }

        [JsonProperty("display_type")]
        public string DisplayType { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("product_icon")]
        public EntityPayloadAttributeProductIcon ProductIcon { get; set; }

        [JsonProperty("full_size_preview")]
        public EntityPayloadFullSizePreview FullSizePreview { get; set; }

        [JsonProperty("metadata_last_modified")]
        public long? MetadataLastModified { get; set; }
    }
}