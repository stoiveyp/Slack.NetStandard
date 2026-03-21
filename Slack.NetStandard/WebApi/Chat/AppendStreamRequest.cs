using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Slack.NetStandard.Messages.StreamChunks;

namespace Slack.NetStandard.WebApi.Chat;

/// <summary>
/// Appends text to an existing streaming conversation.
/// </summary>
/// <remarks>https://docs.slack.dev/reference/methods/chat.appendStream</remarks>
public class AppendStreamRequest
{
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("ts")]
    public Timestamp Timestamp { get; set; }
    
    /// <summary>
    /// Accepts message text formatted in markdown. Limit this field to 12,000 characters. This text is what will be appended to the message received so far.
    /// </summary>
    [JsonProperty("markdown_text")]
    public string MarkdownText { get; set; }

    [JsonProperty("chunks", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IList<IStreamChunk> Chunks { get; set; } = null;

    public bool ShouldSerializeChunks() => Chunks?.Any() ?? false;
}