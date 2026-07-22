using Newtonsoft.Json;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.Messages.Elements
{
    public class Image:IContextElement,IMessageElement
    {
        public Image(){}

        public Image(string imageUrl, string altText)
        {
            ImageUrl = imageUrl;
            AltText = altText;
        }

        public string Type => nameof(Image).ToLower();

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("slack_file", NullValueHandling = NullValueHandling.Ignore)]
        public SlackFile SlackFile { get; set; }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }
    }
}
