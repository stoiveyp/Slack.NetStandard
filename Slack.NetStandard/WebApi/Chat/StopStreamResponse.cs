using Newtonsoft.Json;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.WebApi.Chat;

/// <summary>
/// Typical success response when stopping a streaming message
/// </summary>
/// <remarks>https://docs.slack.dev/reference/methods/chat.stopStream#response</remarks>
public class StopStreamResponse : MessageResponse
{
    [JsonProperty("message",NullValueHandling = NullValueHandling.Ignore)]
    public Message Message { get; set; }
}