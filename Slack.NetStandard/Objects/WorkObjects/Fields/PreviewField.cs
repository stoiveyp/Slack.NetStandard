using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects.Fields
{
    public class PreviewField
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}