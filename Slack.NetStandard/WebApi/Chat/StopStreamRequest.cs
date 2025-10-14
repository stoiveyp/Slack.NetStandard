using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using System.Linq;

namespace Slack.NetStandard.WebApi.Chat;

/// <summary>
/// Stops a streaming conversation.
/// </summary>
/// <remarks>https://docs.slack.dev/reference/methods/chat.stopStream</remarks>
public class StopStreamRequest
{
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("ts")]
    public Timestamp Timestamp { get; set; }
    
    /// <summary>
    /// Accepts message text formatted in markdown. Limit this field to 12,000 characters. This text is what will be appended to the message received so far.
    /// </summary>
    [JsonProperty("markdown_text", NullValueHandling = NullValueHandling.Ignore)]
    public string MarkdownText { get; set; }
    
    /// <summary>
    /// A list of blocks that will be rendered at the bottom of the finalized message.
    /// </summary>
    [JsonProperty("blocks", NullValueHandling = NullValueHandling.Ignore)]
    public IList<IMessageBlock> Blocks { get; set; } = new List<IMessageBlock>();
    
    /// <summary>
    /// JSON object with event_type and event_payload fields, presented as a URL-encoded string. Metadata you post to Slack is accessible to any app or user who is a member of that workspace.
    /// </summary>
    [JsonProperty("metadata",NullValueHandling = NullValueHandling.Ignore)]
    public MessageMetadata Metadata { get; set; }

    public bool ShouldSerializeBlocks() => Blocks?.Any() ?? false;
}