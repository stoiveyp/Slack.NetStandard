using Newtonsoft.Json;
using System.Collections.Generic;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages.Blocks
{
    public class PieChart : IChart
    {
        public const string ChartType = "pie";
        [JsonProperty("type")] public string Type => ChartType;

        [JsonProperty("segments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Segment> Segments { get; set; } = new();
        public bool ShouldSerializeSegments() => Segments?.Count > 0;
    }
}
