using Newtonsoft.Json;

namespace Slack.NetStandard.WebApi.Chat;

/// <summary>
/// Starts a new streaming conversation.
/// </summary>
/// <remarks>https://docs.slack.dev/reference/methods/chat.startStream</remarks>
public class StartStreamRequest
{
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("thread_ts")]
    public Timestamp ThreadTimestamp { get; set; }
    
    /// <summary>
    /// Accepts message text formatted in markdown. Limit this field to 12,000 characters. This text is what will be appended to the message received so far.
    /// </summary>
    [JsonProperty("markdown_text", NullValueHandling = NullValueHandling.Ignore)]
    public string MarkdownText { get; set; }
    
    /// <summary>
    /// The encoded ID of the user to receive the streaming text. Required when streaming to channels.
    /// </summary>
    [JsonProperty("recipient_user_id", NullValueHandling = NullValueHandling.Ignore)]
    public string RecipientUserId { get; set; }
    
    /// <summary>
    /// The encoded ID of the team the user receiving the streaming text belongs to. Required when streaming to channels.
    /// </summary>
    [JsonProperty("recipient_team_id", NullValueHandling = NullValueHandling.Ignore)]
    public string RecipientTeamId { get; set; }
}