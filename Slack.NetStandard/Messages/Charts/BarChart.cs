using Newtonsoft.Json;
using System.Collections.Generic;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.Messages.Blocks
{
    public class BarChart : IChart
    {
        public const string ChartType = "bar";
        [JsonProperty("type")] public string Type => ChartType;

        [JsonProperty("series", NullValueHandling = NullValueHandling.Ignore)]
        public List<Series> Series { get; set; } = new();

        [JsonProperty("axis_config", NullValueHandling = NullValueHandling.Ignore)]
        public AxisConfig AxisConfig { get; set; }
        public bool ShouldSerializeSeries() => Series?.Count > 0;
    }
}
