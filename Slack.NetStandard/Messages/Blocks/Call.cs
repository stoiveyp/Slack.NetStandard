using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.Blocks;

public class Call : IMessageBlock
{
    public Call(){}

    public Call(string callId)
    {
        CallId = callId;
    }

    [JsonProperty("type")] public string Type => nameof(Call).ToLower();

    [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
    public string BlockId { get; set; }

    [JsonProperty("call_id",NullValueHandling = NullValueHandling.Ignore)]
    public string CallId { get; set; }
}