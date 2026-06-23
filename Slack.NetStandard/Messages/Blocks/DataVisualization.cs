using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class DataVisualization : IMessageBlock
    {
        public const string MessageBlockType = "data_visualization";
        [JsonProperty("type")] public string Type => MessageBlockType;

        public DataVisualization() { }

        public DataVisualization(string title)
        {
            Title = title;
        }

        [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("chart", NullValueHandling = NullValueHandling.Ignore)]
        public IChart Chart { get; set; }
    }
}
