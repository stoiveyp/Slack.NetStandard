using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadAttributeProductIcon
    {
        public EntityPayloadAttributeProductIcon() { }

        public EntityPayloadAttributeProductIcon(string altText, SlackFile slackFile) : this(altText)
        {
            SlackFile = slackFile;
        }

        public EntityPayloadAttributeProductIcon(string altText, string url):this(altText)
        {
            Url = url;
        }

        protected EntityPayloadAttributeProductIcon(string altText)
        {
            AltText = altText;
        }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("slack_file")]
        public SlackFile SlackFile { get; set; }
    }
}