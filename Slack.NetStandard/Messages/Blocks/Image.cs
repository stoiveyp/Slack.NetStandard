using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Image : IMessageBlock
    {
        public Image(){}

        public Image(string imageUrl, string altText)
        {
            ImageUrl = imageUrl;
            AltText = altText;
        }

        [JsonProperty("type")]
        public string Type => nameof(Image).ToLower();

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("slack_file", NullValueHandling = NullValueHandling.Ignore)]
        public SlackFile SlackFile { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("title",NullValueHandling = NullValueHandling.Ignore)]
        public PlainText Title { get; set; }

        [JsonProperty("block_id",NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }
    }
}