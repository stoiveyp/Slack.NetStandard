using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class DataPoint
    {
        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("value")] public int Value { get; set; }
    }
}
