using Newtonsoft.Json;
using Slack.NetStandard.JsonConverters;

namespace Slack.NetStandard.Messages.Blocks
{
    [JsonConverter(typeof(TaskCardElementConverter))]
    public interface ITaskCardElement
    {
        [JsonProperty("type")]
        string Type { get; }
    }
}
