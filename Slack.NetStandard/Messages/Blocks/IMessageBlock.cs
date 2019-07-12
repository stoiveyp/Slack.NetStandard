using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks
{
    public interface IMessageBlock
    {
        [JsonProperty("type")]
        string Type { get; }

    }
}
