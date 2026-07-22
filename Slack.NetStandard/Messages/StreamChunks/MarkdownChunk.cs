using Newtonsoft.Json;

namespace Slack.NetStandard.Messages.StreamChunks;

public class MarkdownChunk : IStreamChunk
{
    [JsonProperty("type")]
    public string Type { get; set; } = "markdown_text";
    
    [JsonProperty("text")]
    public string Text { get; set; }
}