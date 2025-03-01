using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Markdown : IMessageBlock
    {
        public Markdown() { }
        public Markdown(string text) { Text = text; }

        public string Type => nameof(Markdown).ToLower();

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
