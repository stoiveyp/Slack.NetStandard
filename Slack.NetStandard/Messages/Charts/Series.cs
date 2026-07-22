using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack.NetStandard.Messages.Blocks
{
    public class Series
    {
        public Series() { }

        public Series(string name, params DataPoint[] data) : this()
        {
            Name = name;
            Data = [.. data];
        }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<DataPoint> Data { get; set; } = new();
        public bool ShouldSerializeData() => Data?.Count > 0;
    }
}
