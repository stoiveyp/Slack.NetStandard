using Newtonsoft.Json;

namespace Slack.NetStandard.Objects.WorkObjects
{
    public class EntityPayloadIcon
    {
        public EntityPayloadIcon() { }

        public EntityPayloadIcon(string altText, SlackFile slackFile) : this(altText)
        {
            SlackFile = slackFile;
        }

        public EntityPayloadIcon(string altText, string url):this(altText)
        {
            Url = url;
        }

        protected EntityPayloadIcon(string altText)
        {
            AltText = altText;
        }

        [JsonProperty("alt_text")]
        public string AltText { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("slack_file", NullValueHandling = NullValueHandling.Ignore)]
        public SlackFile SlackFile { get; set; }
    }
}