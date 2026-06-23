using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Segment
    {
        public Segment() { }
        public Segment(string label, int value)
        {
            Label = label;
            Value = value;
        }

        [JsonProperty("label")] public string Label { get; set; }
        [JsonProperty("value")] public int Value { get; set; }
    }
}
