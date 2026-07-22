using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Blocks
{
    public class AxisConfig
    {
        public AxisConfig() { }
        public AxisConfig(string xLabel, string yLabel, params string[] categories) : this()
        {
            XLabel = xLabel;
            YLabel = yLabel;
            Categories = [.. categories];
        }
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Categories { get; set; } = new();

        [JsonProperty("x_label", NullValueHandling = NullValueHandling.Ignore)]
        public string XLabel { get; set; }

        [JsonProperty("y_label", NullValueHandling = NullValueHandling.Ignore)]
        public string YLabel { get; set; }
        public bool ShouldSerializeCategories() => Categories?.Count > 0;
    }
}
