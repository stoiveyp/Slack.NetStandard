using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.StreamChunks;

public class PlanUpdateChunk : IStreamChunk
{
    [JsonProperty("type")]
    public string Type { get; set; } = "plan_update";
    
    [JsonProperty("title")]
    public string Title { get; set; }
}