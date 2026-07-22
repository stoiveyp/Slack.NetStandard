using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(ChartConverter))]
    public interface IChart
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
