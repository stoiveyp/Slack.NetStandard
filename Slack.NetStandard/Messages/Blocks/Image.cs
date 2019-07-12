using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Image : IMessageBlock
    {
        public string Type => nameof(Image).ToLower();

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Title { get; set; }

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }
    }
}