using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadFullSizePreview
    {
        public EntityPayloadFullSizePreview() { }

        public EntityPayloadFullSizePreview(bool isSupported, string previewUrl, string mimeType)
        {
            IsSupported = isSupported;
            PreviewUrl = previewUrl;
            MimeType = mimeType;
        }

        [JsonProperty("is_supported")]
        public bool IsSupported { get; set; }
        
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public FullSizePreviewError Error { get; set; }
    }
}