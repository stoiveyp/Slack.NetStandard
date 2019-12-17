using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Elements
{
    public class Confirmation
    {
        [JsonProperty("title")]
        public PlainText Title { get; set; }

        [JsonProperty("text")]
        public TextObject Text { get; set; }

        [JsonProperty("confirm")]
        public PlainText Confirm { get; set; }

        [JsonProperty("deny")]
        public PlainText Deny { get; set; }
    }
}
